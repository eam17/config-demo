using System;
using CoreAnimation;
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
            //this.Accessory = UITableViewCellAccessory.None;
            //// Note: this .ctor should not contain any initialization logic.
            //var gradientLayer = new CAGradientLayer();
            //gradientLayer.Colors = new[] { UIColor.Red.CGColor, UIColor.Blue.CGColor };
            //gradientLayer.Locations = new NSNumber[] { 0, 1 };
            //gradientLayer.Frame = this.Frame;
            //gradientLayer.Opacity = 0.5f;
            var z = this.Frame;
            ////this.TableView.BackgroundColor = UIColor.Clear;
            //this.Layer.InsertSublayer(gradientLayer, 0);

            //this.Accessory = UITableViewCellAccessory.None;
        }

        public void Bind(string key)
        {
            this.KeyLabel.Text = key;
            this.ValueLabel.Text = string.Empty;
            this.KeyLabel.Font = UIFont.FromName("NotoSansKannada-Regular", 20f);
            this.KeyLabel.TextColor = UIColor.FromName("color-yellow");
            this.KeyLabel.TextAlignment = UITextAlignment.Left;
        }
    }
}
