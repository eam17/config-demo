using System;
using System.Collections.Generic;
using ConfigDemo.Models;

namespace ConfigDemo.PubSub
{
    public class RowTappedEvent
    {
        //public List<(string Key, object Value)> ItemsList = ModelsDictionaries.GetList();

        public RowTappedEvent(object children)
        {
            //this.ItemsList = children;
            //DataSource.Instance.currentNodes = children;
            if (children.GetType().ToString() == "System.List")
            {
                ModelsDictionaries.CurrentList = (List<(string Key, object Value)>)children;
            }

        }
    }
}
