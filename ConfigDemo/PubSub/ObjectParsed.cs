using System;
using System.Collections.Generic;
using Android.Hardware.Camera2;
using ConfigDemo.Models;

namespace ConfigDemo.PubSub
{
    public class ObjectParsed
    {
        public static List<(string Key, object Value)> ItemsList;
        public static Root Root;

        public ObjectParsed(Root rootObject)
        {
            Root = rootObject;
        }

    }
    
}
