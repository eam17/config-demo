using System;
using System.Collections.Generic;

namespace AndroidRecyclerViewDemo
{
    public class ItemsToFill
    {
        public List<TitleAndDescModel> childrenToDisplay = new List<TitleAndDescModel>();

        public ItemsToFill(List<TitleAndDescModel> children)
        {
            this.childrenToDisplay = children;
        }
    }
}
