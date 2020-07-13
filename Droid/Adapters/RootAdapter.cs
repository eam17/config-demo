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
            RowViewHolder vh = (RowViewHolder)holder; //as RowViewHolder 

            // Set the TextView in this ViewHolder's CardView from this position in the photo album:
            vh._ItemText.Text = "hello";
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
