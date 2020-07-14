using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using ConfigDemo.Models;
using ConfigDemo.Network;
using ConfigDemo.Droid.Adapters;

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

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.RootRecyclerViewLayout);

            // Get our RecyclerView layout:
            this._View = FindViewById<RecyclerView>(Resource.Id.root_recycler_view);


            // Prepare the data source
            GetRoot();


            // Plug in the linear layout manager
            this._RootLayoutManager = new LinearLayoutManager(this);
            this._View.SetLayoutManager(this._RootLayoutManager);

        }

        async void GetRoot()
        {
            this._Root = await new NetworkKat().GetRootObject<Root>();
            if (this._Root != null)
            {
                this._RootAdapter = new RootAdapter(this._Root);
                this._View.SetAdapter(this._RootAdapter);
            }
        }

    }
}

