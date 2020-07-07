// This file has been autogenerated from a class added in the UI designer.

using System;
using ConfigDemo.iOS.Datasources;
using ConfigDemo.Models;
using ConfigDemo.Network;
using ExampleApp.iOS.Datasource;
using Foundation;
using UIKit;

namespace ConfigDemo.iOS
{
    public partial class SecondLevelViewController : UIViewController
    {
        //make them not public
        public LoginModes _Modes;
        public Clients _Clients;

        bool _IsModes => this._Modes != null;
        bool _IsClients => this._Clients != null;
        public SecondLevelViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.TableView.RegisterNibForCellReuse(ObjectTableViewCell.Nib, ObjectTableViewCell.Key);
            this.TableView.RowHeight = UITableView.AutomaticDimension;
            this.TableView.EstimatedRowHeight = 44;
            this.TableView.TableFooterView = new UIView();

            if (this._IsModes)
            {
                GetModes();
            }
            else if (this._IsClients)
            {
                GetClients();
            }

            

        }

        void GetModes()
        {
            var source = new ModesDatasource(this._Modes, this);
            this.TableView.Source = source;
            this.TableView.ReloadData();
        }

        void GetClients()
        {
            var source = new ClientsDatasource(this._Clients, this);
            this.TableView.Source = source;
            this.TableView.ReloadData();
        }

        public void NavigateToOrganizations()
        {
            OrganizationsViewController vc = (OrganizationsViewController)this.Storyboard.InstantiateViewController("OrganizationsViewController");
            vc._Org = this._Modes.Organizations;
            vc.Title = "Organizations";
            this.NavigationController.PushViewController(vc, true);
        }

        public void NavigateToClientOption(int indexPathRow)
        {
            ClientOptionViewController vc = (ClientOptionViewController)this.Storyboard.InstantiateViewController("ClientOptionViewController");
            var title = string.Empty;
            switch (indexPathRow)
            {
                case 0:
                    vc._ClientOption = this._Clients.Web;
                    title = "Web";
                    break;
                case 1:
                    vc._ClientOption = this._Clients.Android;
                    title = "Android";
                    break;
                case 2:
                    vc._ClientOption = this._Clients.iOS;
                    title = "iOS";
                    break;
                default:
                    break;
            }
            vc.Title = title;
            this.NavigationController.PushViewController(vc, true);
        }

    }
}