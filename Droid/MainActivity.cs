using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using ConfigDemo.Models;
using ConfigDemo.Network;
using ConfigDemo.Droid.Adapters;
using ConfigDemo.PubSub;
using System;

namespace ConfigDemo.Droid
{
    [Activity(Label = "ConfigDemo", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        RecyclerView _View;
        private RecyclerView.Adapter _RootAdapter;
        private RecyclerView.LayoutManager _RootLayoutManager;

        Root _Root;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //subscribe + add method
            new ModelsDictionaries();
            this.Subscribe<ListPopulated>(SetDatasource);
            this.Subscribe<RowTappedEvent>(ResetDatasource);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.RootRecyclerViewLayout);

            // Get our RecyclerView layout:
            this._View = FindViewById<RecyclerView>(Resource.Id.root_recycler_view);




            // Plug in the linear layout manager
            this._RootLayoutManager = new LinearLayoutManager(this);
            this._View.SetLayoutManager(this._RootLayoutManager);

        }

        private void ResetDatasource(RowTappedEvent obj)
        {
            this._RootAdapter = new RootAdapter(ModelsDictionaries.CurrentList);
            this._View.SetAdapter(this._RootAdapter);
        }

        void SetDatasource(ListPopulated obj)
        {
            this._RootAdapter = new RootAdapter(ModelsDictionaries.ItemsList);
            this._View.SetAdapter(this._RootAdapter);
           
        }

    }
}

