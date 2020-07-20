using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using ConfigDemo.Models;

namespace ConfigDemo.Droid.Adapters
{
    // Datasource
    public class RootAdapter : RecyclerView.Adapter
    {
        // Underlying data set
        List<(string Key, object Value)> _ItemsList;
        List<(string Key, object Value)> _CurrentList;
        // Load the adapter with the data set at construction time
        public RootAdapter(List<(string Key, object Value)> items)
        {
            this._ItemsList = items;
            this._CurrentList = ModelsDictionaries.CurrentList;
        }

        // Create a new row
        // GetCell?
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the View for the item
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CellLayout, parent, false);

            // Create a ViewHolder to find and hold these view references
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

            key = this._CurrentList[position].Key;
            var valueType = this._CurrentList[position].Value.GetType().ToString();
            if (valueType == "System.String" || valueType == "System.Boolean")
            {
                value = this._CurrentList[position].Value.ToString();
            }

            row.RowPosition = position;
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
