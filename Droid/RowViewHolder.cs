using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ConfigDemo.Models;
using ConfigDemo.PubSub;

namespace ConfigDemo.Droid
{
    // View controller for the row only? cell?
    public class RowViewHolder : RecyclerView.ViewHolder
    {
        public TextView _ItemKey { get; private set; }
        public TextView _ItemValue { get; private set; }
        public List<(string Key, object Value)> ItemsList;
        public int RowPosition { get; set; }

        //Bind
        public RowViewHolder(View itemView) : base(itemView)
        {
            this._ItemKey = itemView.FindViewById<TextView>(Resource.Id.cell_text_view_key);
            this._ItemValue = itemView.FindViewById<TextView>(Resource.Id.cell_text_view_value);
            itemView.Click += ViewTapped;
        }

        void ViewTapped(object sender, EventArgs e)
        {
            //pass in where we want to get to
            
            this.Publish(new RowTappedEvent(ModelsDictionaries.ItemsList[this.RowPosition].Value));
        }
    }
}
