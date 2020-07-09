using System;
using System.Drawing;
using CoreAnimation;
using CoreGraphics;
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
            
        }

        public void Bind(string key, string value)
        {
            this.KeyLabel.Text = key;
            this.ValueLabel.Text = value;

            this.KeyLabel.TextAlignment = UITextAlignment.Left;
            this.ValueLabel.TextAlignment = UITextAlignment.Left;

            this.KeyLabel.Font = UIFont.FromName("NotoSansKannada-Regular", 20f);
            this.KeyLabel.TextColor = UIColor.FromName("color-yellow");

            this.ValueLabel.Font = UIFont.FromName("NotoSansKannada-Light", 17f);

            var purpleColor = UIColor.FromName("color-purple");
            var redColor = UIColor.FromName("color-red");
            var greenColor = UIColor.FromName("color-green");

            this.ValueLabel.TextColor = value.Equals("True") ? greenColor : value.Equals("False") ? redColor : purpleColor;



            var gradientLayer = new CAGradientLayer();
            gradientLayer.Colors = new[] { UIColor.Red.CGColor, UIColor.Blue.CGColor };
            gradientLayer.Locations = new NSNumber[] { 0, 1 };

            var rect = new CGRect(0, 0, this.Layer.Frame.Width, this.Layer.Frame.Height);

            gradientLayer.Frame = rect;
            gradientLayer.Opacity = 0.5f;

            //this.TableView.BackgroundColor = UIColor.Clear;
            this.Layer.InsertSublayer(gradientLayer, 1);
        }
    }
}
