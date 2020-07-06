using System;

using UIKit;

namespace ConfigDemo.iOS
{
    public partial class DetailViewController : UIViewController
    {
        public DetailViewController() : base("DetailViewController", null)
        {
        }

        protected internal DetailViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

