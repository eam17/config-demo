using System;
using System.Runtime.InteropServices.ComTypes;
using ConfigDemo.Models;
using ConfigDemo.Network;
using ConfigDemo.PubSub;
using CoreAnimation;
using ExampleApp.iOS.Datasource;
using Foundation;
using UIKit;

namespace ConfigDemo.iOS
{
    public partial class ViewController : UITableViewController
    {
        int count = 1;
        //public Root _Root;
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

                this.TableView.BackgroundColor = UIColor.FromName("color-dark-2");

                this.NavigationController.NavigationBar.BarTintColor = UIColor.FromName("color-teal-dark");
                this.NavigationController.NavigationBar.TintColor = UIColor.FromName("color-dark-1");
                this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes()
                {
                    ForegroundColor = UIColor.FromName("color-dark-2")
                };

            new ModelsDictionaries();
            // Perform any additional setup after loading the view, typically from a nib.
            //GetRoot();

            this.Subscribe<ListPopulated>(SetDatasource);

            RootDatasource source = new RootDatasource(ModelsDictionaries.ItemsList, this);
        }


        public void NavigateToLoginModes()
        {
            var sb = UIStoryboard.FromName("Main", null);
            SecondLevelViewController vc = (SecondLevelViewController)sb.InstantiateViewController("SecondLevelViewController");
            //vc._Modes = this._Root.LoginModes;
            vc.Title = "Login Modes";

            this.NavigationController.PushViewController(vc, true);
        }

        public void NavigateToClients()
        {
            SecondLevelViewController vc = (SecondLevelViewController)this.Storyboard.InstantiateViewController("SecondLevelViewController");
            //vc._Clients = this._Root.Clients;
            vc.Title = "Clients";
            this.NavigationController.PushViewController(vc, true);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

        void SetDatasource(ListPopulated obj)
        {
            
            //this.TableView.Source = source;
            this.TableView.ReloadData();
        }

        
    }
}
