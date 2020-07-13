using System;
using System.Collections.Generic;

namespace AndroidRecyclerViewDemo
{
    public class RowTappedEvent
    {
        public List<TitleAndDescModel> currentNodes = new List<TitleAndDescModel>();

        public RowTappedEvent(List<TitleAndDescModel> children)
        {
            this.currentNodes= children;
            DataSource.Instance.currentNodes = children;
        }
    }
}
