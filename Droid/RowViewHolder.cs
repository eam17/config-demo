using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace ConfigDemo.Droid
{
    // View controller for the row only?
    public class RowViewHolder : RecyclerView.ViewHolder
    {
        public TextView _ItemText { get; private set; }

        public RowViewHolder(View itemView) : base(itemView)
        {
            this._ItemText = itemView.FindViewById<TextView>(Resource.Id.cell_text_view);

        }
    }
}
