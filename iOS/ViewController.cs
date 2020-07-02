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
        ObjectTableViewCell _ObjectCell;
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.TableView.RegisterNibForCellReuse(ObjectTableViewCell.Nib, ObjectTableViewCell.Key);
            this.TableView.RegisterNibForCellReuse(PropertyTableViewCell.Nib, PropertyTableViewCell.Key);
            this.TableView.RowHeight = UITableView.AutomaticDimension;
            this.TableView.EstimatedRowHeight = 44;
            this.TableView.TableFooterView = new UIView();

            // Perform any additional setup after loading the view, typically from a nib.
            GetRoot();

        }

        void NavigateToSecongLevel()
        {
            var sb = UIStoryboard.FromName("Main", null);
            var vc = sb.InstantiateViewController("SecondLevelViewController");
            //var vc2 = this.Storyboard.InstantiateViewController("SecondLevelViewController");
            this.NavigationController.PushViewController(vc, true);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
        async void GetRoot()
        {
            this._Root = await new NetworkKat().GetRootObject<Root>();
            var source = new ItemsDatasource(this._Root);
            this.TableView.Source = source;
            this.TableView.ReloadData();
        }
    }
}
