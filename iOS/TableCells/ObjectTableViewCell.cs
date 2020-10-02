using System;
using CoreAnimation;
using Foundation;
using UIKit;

namespace AttributeDemo.iOS
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
        }

        public void Bind(string key)
        {
            this.KeyLabel.Text = key;
            this.ValueLabel.Text = string.Empty;
            this.KeyLabel.TextAlignment = UITextAlignment.Left;
        }
    }
}
