// Copied from upta/PubSub
// https://github.com/upta/pubsub
// Brought in as code instead of import to avoid compiler issues

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConfigDemo.PubSub
{
    public class Hub
    {

        public interface IInvoker
        {
            void Invoke(Action act);
        }

        internal class Handler
        {
            public Delegate Action { get; set; }
            public WeakReference Sender { get; set; }
            public Type Type { get; set; }
        }

        public IInvoker Invoker { get; set; }
        internal object _Locker = new object();
        internal List<Handler> _Handlers = new List<Handler>();

        /// <summary>
        /// Allow publishing directly onto this Hub.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        public void Publish<T>(T data = default(T))
        {
            Publish(this, data);
        }

        public void Publish<T>(object sender, T data = default(T))
        {
            if (sender == null) return;
            var handlerList = new List<Handler>(_Handlers.Count);
            var handlersToRemoveList = new List<Handler>(_Handlers.Count);

            lock (this._Locker)
            {
                foreach (var handler in _Handlers)
                {
                    if (!handler.Sender.IsAlive)
                    {
                        handlersToRemoveList.Add(handler);
                    }
                    else if (handler.Type.GetTypeInfo().IsAssignableFrom(typeof(T).GetTypeInfo()))
                    {
                        handlerList.Add(handler);
                    }
                }

                foreach (var l in handlersToRemoveList)
                {
                    _Handlers.Remove(l);
                }
            }

            foreach (var l in handlerList)
            {
                if (this.Invoker != null)
                {
                    this.Invoker.Invoke(() => ((Action<T>)l.Action)(data));
                }
                else
                {
                    ((Action<T>)l.Action)(data);
                }

            }
        }

        /// <summary>
        /// Allow subscribing directly to this Hub.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler"></param>
        public void Subscribe<T>(Action<T> handler)
        {
            Subscribe(this, handler);
        }

        public void Subscribe<T>(object sender, Action<T> handler)
        {
            var item = new Handler
            {
                Action = handler,
                Sender = new WeakReference(sender),
                Type = typeof(T)
            };

            lock (this._Locker)
            {
                this._Handlers.Add(item);
            }
        }

        /// <summary>
        /// Checks if a subscription exists for this class of that T type.
        /// Private.  Does not lock context.  Avoid using this if you can.
        /// </summary>
        /// <typeparam name="T">Type of object being listened for</typeparam>
        /// <param name="sender">Object subscribed</param>
        /// <returns>True if that sender<T> exists</returns>
        bool HasSubscriptionNoLock<T>(object sender)
        {
            bool found = false;
            foreach (var h in _Handlers)
            {
                if (Equals(h.Sender.Target, sender) &&
                    typeof(T) == h.Type)
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        /// <summary>
        /// Checks if a subscription exists for this class of that T type.
        /// Avoid using this if you can.
        /// </summary>
        /// <typeparam name="T">Type of object being listened for</typeparam>
        /// <param name="sender">Object subscribed</param>
        /// <returns>True if that sender<T> exists</returns>
        public bool HasSubscription<T>(object sender)
        {
            lock(this._Locker)
            {
                return HasSubscriptionNoLock<T>(sender);
            }
        }

        /// <summary>
        /// Subscribes if the listening object does not have a registered method already for said T type
        /// </summary>
        /// <typeparam name="T">Object to subscribe for</typeparam>
        /// <param name="sender">Object that wants the publish</param>
        /// <param name="handler">Method that receives the publish</param>
        /// <returns>True if subscription was successful</returns>
        public bool TrySubscribe<T>(object sender, Action<T> handler)
        {
            bool didSub = false;
            lock(this._Locker)
            {
                if(this.HasSubscriptionNoLock<T>(sender) == false)
                {
                    Subscribe(sender, handler);
                    didSub = true;
                }
            }
            return didSub;
        }

        /// <summary>
        /// Allow unsubscribing directly to this Hub.
        /// </summary>
        public void Unsubscribe()
        {
            Unsubscribe(this);
        }

        public void Unsubscribe(object sender)
        {
            lock (this._Locker)
            {
                var query = this._Handlers.Where(a => !a.Sender.IsAlive ||
                                                     a.Sender.Target.Equals(sender));

                foreach (var h in query.ToList())
                {
                    this._Handlers.Remove(h);
                }
            }
        }

        /// <summary>
        /// Allow unsubscribing directly to this Hub.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler"></param>
        public void Unsubscribe<T>(Action<T> handler = null)
        {
            Unsubscribe<T>(this, handler);
        }

        public void Unsubscribe<T>(object sender, Action<T> handler = null)
        {
            lock (this._Locker)
            {
                var query = this._Handlers
                    .Where(a => !a.Sender.IsAlive ||
                                (a.Sender.Target.Equals(sender) && a.Type == typeof(T)));

                if (handler != null)
                {
                    query = query.Where(a => a.Action.Equals(handler));
                }

                foreach (var h in query.ToList())
                {
                    this._Handlers.Remove(h);
                }
            }
        }

        /// <summary>
        /// Removes all handlers from the subscription list.
        /// </summary>
        public void FlushSubscriptions(bool debugPrint = false)
        {
            lock(this._Locker)
            {
                if(debugPrint)
                {
                    this.LogLine();
                    this.Log("FLUSHING ALL SUBSCRIPTIONS!!!");
                    this.PrintSubscriptions();
                }
                
                this._Handlers = new List<Handler>();

                if(debugPrint)
                {
                    this.Log("FLUSH DONE!!!");
                    this.Log(" - Existing subs: " + this._Handlers.Count);
                    this.LogLine();
                }
                
            }
        }

        /// <summary>
        /// Prints all existing subscriptions.  It will print the object and its memory address
        /// plus the expected <T> for its subscription.
        /// </summary>
        public void PrintSubscriptions()
        {
            lock(this._Locker)
            {
                this.Log(" - Existing subs: " + this._Handlers.Count);
                foreach (var h in this._Handlers)
                {
                    this.Log(" + " + h.Action.Target + " / " + h.Type);    
                }
            }
        }
    }
}