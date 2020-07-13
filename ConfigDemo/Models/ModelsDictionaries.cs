using System;
using System.Collections.Generic;
using ConfigDemo.Network;

namespace ConfigDemo.Models
{
    public class ModelsDictionaries : Dictionary<string, object>
    {
        public static Dictionary<string, object> dict = new Dictionary<string, object>();
        Root _Root;

        public ModelsDictionaries()
        {
            GetRoot();

            dict.Add("LoginModes", this._Root.LoginModes);
            dict.Add("Clients", this._Root.Clients);
            dict.Add("IsProduction", this._Root.IsProduction);
            dict.Add("ApiDomain", this._Root.ApiDomain);
            dict.Add("PingOneLogoutUrl", this._Root.PingOneLogoutUrl);
            dict.Add("Version", this._Root.Version);


        }

        async void GetRoot()
        {
            this._Root = await new NetworkKat().GetRootObject<Root>();
        }


    }
}
