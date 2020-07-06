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
            this.TableView.RegisterNibForCellReuse(PropertyTableViewCell.Nib, PropertyTableViewCell.Key);
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
    }
}