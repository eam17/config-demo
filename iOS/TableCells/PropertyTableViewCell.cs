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

            this.KeyLabel.TextAlignment = UITextAlignment.Left;
            this.ValueLabel.TextAlignment = UITextAlignment.Left;

            this.KeyLabel.Font = UIFont.FromName("NotoSansKannada-Regular", 20f);
            this.ValueLabel.Font = UIFont.FromName("NotoSansKannada-Light", 17f);

            var grayColor = new UIColor(red: 0.2f, green: 0.2f, blue: 0.2f, alpha: 1.00f);
            var redColor = new UIColor(red: 0.90f, green: 0.04f, blue: 0.11f, alpha: 1.00f);
            var greenColor = new UIColor(red: 0.18f, green: 0.45f, blue: 0.12f, alpha: 1.00f);

            this.ValueLabel.TextColor = value.Equals("True") ? greenColor : value.Equals("False") ? redColor : grayColor;

        }
    }
}
