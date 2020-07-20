// Copied from upta/PubSub
// https://github.com/upta/pubsub
// Brought in as code instead of import to avoid compiler issues

using System;

namespace ConfigDemo.PubSub
{
    /// <summary>
    /// Pub-sub extension methods available to all objects within myStrength.
    /// </summary>
    static public class PubSubExtensions
    {
        #region Global Services
        /// <summary>
        /// The global pub-sub <see cref="Hub"/> instance for async 
        /// event transmission between background threads and the UI thread.
        /// </summary>
        public static readonly Hub PubHub = new Hub();

        #endregion

        #region Extension Methods
        static public bool HasSubscription<T>(this object obj)
        {
            return PubHub.HasSubscription<T>(obj);
        }

        static public void Publish<T>(this object obj)
        {
            PubHub.Publish(obj, default(T));
        }

        static public void Publish<T>(this object obj, T data)
        {
            PubHub.Publish(obj, data);
        }

        static public void Subscribe<T>(this object obj, Action<T> handler)
        {
            PubHub.Subscribe(obj, handler);
        }

        /// <summary>
        /// Used to safely subcribe and not double-subscribe.  Be warned that this can be
        /// an expensive operation so do not use it too often.
        /// </summary>
        /// <typeparam name="T">The published object type</typeparam>
        /// <param name="obj">The object that wants to subscribe</param>
        /// <param name="handler">The action to be handled</param>
        /// <returns>If the object was subscribed</returns>
        static public bool TrySubscribe<T>(this object obj, Action<T> handler)
        {
            return PubHub.TrySubscribe<T>(obj, handler);
        }

        static public void Unsubscribe(this object obj)
        {
            PubHub.Unsubscribe(obj);
        }

        static public void Unsubscribe<T>(this object obj)
        {
            PubHub.Unsubscribe(obj, (Action<T>)null);
        }

        static public void Unsubscribe<T>(this object obj, Action<T> handler)
        {
            PubHub.Unsubscribe(obj, handler);
        }

        /// <summary>
        /// Very dangerous method!  Only call when you absolutely want all Subscriptions dead!
        /// </summary>
        /// <param name="obj">Caller</param>
        static public void FlushSubscriptions(this object obj, bool debugPrint = false)
        {
            PubHub.FlushSubscriptions(debugPrint);
        }

        /// <summary>
        /// Used to print out all existing subscriptions in the Hub.  Used for debugging.
        /// </summary>
        /// <param name="obj">Caller</param>
        static public void PrintSubscriptions(this object obj)
        {
            PubHub.PrintSubscriptions();
        }
        #endregion


        public static void Log(this object obj, string msg)
        {
           // Console.WriteLine(msg);
        }


        public static void LogLine(this object obj)
        {

        }


    }
}