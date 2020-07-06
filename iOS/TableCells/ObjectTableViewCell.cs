using System;

using Foundation;
using UIKit;

namespace ConfigDemo.iOS
{
    public partial class ObjectTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("ObjectTableViewCell");
        public static readonly UINib Nib;

        static ObjectTableViewCell()
        {
            Nib = UINib.FromName("ObjectTableViewCell", NSBundle.MainBundle);
        }

        protected ObjectTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void Bind(string key)
        {
            this.KeyLabel.Text = key;

            this.ValueLabel.Text = string.Empty;
        }
    }
}
