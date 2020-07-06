using System;

using Foundation;
using UIKit;

namespace ConfigDemo.iOS
{
    public partial class PropertyTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("PropertyTableViewCell");
        public static readonly UINib Nib;

        static PropertyTableViewCell()
        {
            Nib = UINib.FromName("PropertyTableViewCell", NSBundle.MainBundle);
        }

        protected PropertyTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void Bind(string key, string value)
        {
            this.KeyLabel.Text = key;
            this.ValueLabel.Text = value;
        }
    }
}
