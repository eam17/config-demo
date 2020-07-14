using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace ConfigDemo.Droid
{
    // View controller for the row only? cell?
    public class RowViewHolder : RecyclerView.ViewHolder
    {
        public TextView _ItemKey { get; private set; }
        public TextView _ItemValue { get; private set; }

        //Bind
        public RowViewHolder(View itemView) : base(itemView)
        {
            this._ItemKey = itemView.FindViewById<TextView>(Resource.Id.cell_text_view_key);
            this._ItemValue = itemView.FindViewById<TextView>(Resource.Id.cell_text_view_value);
        }
    }
}
