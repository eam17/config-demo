using System;
using System.Runtime.InteropServices.ComTypes;
using ConfigDemo.Models;
using ConfigDemo.Network;
using ExampleApp.iOS.Datasource;
using UIKit;

namespace ConfigDemo.iOS
{
    public partial class ViewController : UITableViewController
    {
        int count = 1;
        public Root _Root;
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

        public void NavigateToLoginModes()
        {
            var sb = UIStoryboard.FromName("Main", null);
            SecondLevelViewController vc = (SecondLevelViewController)sb.InstantiateViewController("SecondLevelViewController");
            vc._Modes = this._Root.LoginModes;
            vc.Title = "Login Modes";

            this.NavigationController.PushViewController(vc, true);
        }

        public void NavigateToClients()
        {
            SecondLevelViewController vc = (SecondLevelViewController)this.Storyboard.InstantiateViewController("SecondLevelViewController");
            vc._Clients = this._Root.Clients;
            vc.Title = "Clients";
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
            RootDatasource source = new RootDatasource(this._Root, this);
            this.TableView.Source = source;
            this.TableView.ReloadData();
        }
    }
}
