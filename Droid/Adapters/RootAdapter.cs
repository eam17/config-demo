using System;
using Android.Support.V7.Widget;
using Android.Views;
using ConfigDemo.Models;

namespace ConfigDemo.Droid.Adapters
{
    // Datasource
    public class RootAdapter : RecyclerView.Adapter
    {
        // Underlying data set
        Root _Root;

        bool _IsRoot => this._Root != null;

        // Load the adapter with the data set at construction time
        public RootAdapter(Root root)
        {
            this._Root = root;
        }

        // Create a new row
        // GetCell?
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the View for the item

            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.CellLayout, parent, false);

            // Create a ViewHolder to find and hold these view references, and 
            // register OnClick with the view holder:
            RowViewHolder vh = new RowViewHolder(itemView);
            return vh;
        }

        // Fill in the contents of the item row(invoked by the layout manager):
        //Bind?
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RowViewHolder row = (RowViewHolder)holder; //as RowViewHolder 

            var key = string.Empty;
            var value = string.Empty;
            if (this._IsRoot)
            {
                switch (position)
                {
                    case 0:
                        key = "LoginModes";
                        break;
                    case 1:
                        key = "Clients";
                        break;
                    case 2:
                        key = "Is Production";
                        value = this._Root.IsProduction.ToString();
                        break;
                    case 3:
                        key = "ApiDomain";
                        value = this._Root.ApiDomain;
                        break;
                    case 4:
                        key = "PingOneLogoutUrl";
                        value = this._Root.PingOneLogoutUrl;
                        break;
                    case 5:
                        key = "Version";
                        value = this._Root.Version;
                        break;
                    default:
                        break;
                }
            }
            row._ItemKey.Text = key;
            row._ItemValue.Text = value;
        }



        public override int ItemCount
        {
            get
            {
                return 6;
            }
        }
    }
}
