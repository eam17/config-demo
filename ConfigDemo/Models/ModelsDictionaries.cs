using System;
using System.Collections.Generic;
using Android.Views.InputMethods;
using ConfigDemo.Network;
using ConfigDemo.PubSub;

namespace ConfigDemo.Models
{
    public class ModelsDictionaries : Dictionary<string, object>
    {
        //make a list instead
        //public static Dictionary<string, object> dict = new Dictionary<string, object>();
        //static Root _Root;
        public static List<(string Key, object Value)> ItemsList;
        public static List<(string Key, object Value)> CurrentList;

        public ModelsDictionaries()
        {
            new NetworkKat().GetRootObject();
            this.Subscribe<ObjectParsed>(GetList);
            
        }

        private void GetList(ObjectParsed obj)
        {
            var items = new List<(string Key, object Value)> { };

            items.Add(("LoginModes", GetLoginModes()));
            items.Add(("Clients", GetClients()));
            items.Add(("IsProduction", ObjectParsed.Root.IsProduction));
            items.Add(("ApiDomain", ObjectParsed.Root.ApiDomain));
            items.Add(("PingOneLogoutUrl", ObjectParsed.Root.PingOneLogoutUrl));
            items.Add(("Version", ObjectParsed.Root.Version));
            ItemsList = items;
            CurrentList = ItemsList;
            this.Publish(new ListPopulated());
        }

        private List<(string Key, object Value)> GetClients()
        {
            var items = new List<(string Key, object Value)> { };
            items.Add(("Web", GetClient(ObjectParsed.Root.Clients.Web)));
            items.Add(("Android", GetClient(ObjectParsed.Root.Clients.Android)));
            items.Add(("iOS", GetClient(ObjectParsed.Root.Clients.iOS)));
            return items;
        }


        private List<(string Key, object Value)> GetClient(ClientObject obj)
        {
            var items = new List<(string Key, object Value)> { };
            items.Add(("Analytics Tracking Code", obj.AnalyticsTrackingCode));
            items.Add(("Minimum Version", obj.MinimumVersion));
            items.Add(("Current Version", obj.CurrentVersion));
            items.Add(("Client Actions", obj.ClientActions));
            items.Add(("Feature Flags", GetFlags(obj.FeatureFlags)));
            items.Add(("Messages", obj.Messages));
            return items;
        }

        private object GetFlags(FeatureFlags flags)
        {
            var items = new List<(string Key, object Value)> { };
            items.Add(("Websockets", flags.Websockets));
            items.Add(("Mobile WA", flags.Websockets));
            items.Add(("Promotions", flags.Websockets));
            items.Add(("Racial Sensitivity Banner", flags.Websockets));
            return items;
        }

        private List<(string Key, object Value)> GetLoginModes()
        {
            var items = new List<(string Key, object Value)> { };
            items.Add(("Organizations", GetOrganizations()));
            return items;
        }

        private List<(string Key, object Value)> GetOrganizations()
        {
            var items = new List<(string Key, object Value)> { };
            items.Add(("Name", ObjectParsed.Root.LoginModes.Organizations[0].Name));
            items.Add(("Program", ObjectParsed.Root.LoginModes.Organizations[0].Program));
            items.Add(("Callback Url", ObjectParsed.Root.LoginModes.Organizations[0].CallbackUrl));
            return items;
        }
    }

    public class ListPopulated
    {
        public ListPopulated()
        {
        }
    }
}
