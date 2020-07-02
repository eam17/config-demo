using System;
using ConfigDemo.Models;
using ConfigDemo.Network;
using ExampleApp.iOS.Datasource;
using UIKit;

namespace ConfigDemo.iOS
{
    public partial class ViewController : UITableViewController
    {
        int count = 1;
        Root _Root;
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.TableView.RegisterNibForCellReuse(ObjectTableViewCell.Nib, ObjectTableViewCell.Key);
            this.TableView.RegisterNibForCellReuse(PropertyTableViewCell.Nib, PropertyTableViewCell.Key);

            // Perform any additional setup after loading the view, typically from a nib.
            GetRoot();

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
        async void GetRoot()
        {
            this._Root = await new NetworkKat().GetRootObject();
            var source = new ItemsDatasource(this._Root);
            this.TableView.Source = source;
        }
    }
}
