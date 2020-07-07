// This file has been autogenerated from a class added in the UI designer.

using System;
using ConfigDemo.Models;
using ConfigDemo.iOS.Datasources;
using Foundation;
using UIKit;

namespace ConfigDemo.iOS
{
    public partial class ClientOptionViewController : UITableViewController
    {
        public ClientObject _ClientOption;
        bool _IsOption => this._ClientOption != null;

        public ClientOptionViewController(IntPtr handle) : base(handle)
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

            if (this._IsOption)
            {
                GetClientoptionItems();
            }


        }

        void GetClientoptionItems()
        {
            var source = new ClientOptionDatasource(this._ClientOption, this);
            this.TableView.Source = source;
            this.TableView.ReloadData();
        }

        //Navigation

        public void NavigateToClientActions()
        {
            ClientActionsViewController vc = (ClientActionsViewController)this.Storyboard.InstantiateViewController("ClientActionsViewController");
            vc._Action = this._ClientOption.ClientActions;
            vc.Title = "Client Actions";
            this.NavigationController.PushViewController(vc, true);
        }

        public void NavigateToFeatureFlags()
        {
            FeatureFlagsViewController vc = (FeatureFlagsViewController)this.Storyboard.InstantiateViewController("FeatureFlagsViewController");
            vc._Flags = this._ClientOption.FeatureFlags;
            vc.Title = "Feature Flags";
            this.NavigationController.PushViewController(vc, true);
        }

        public void NavigateToMessages()
        {
            MessagesViewController vc = (MessagesViewController)this.Storyboard.InstantiateViewController("MessagesViewController");
            vc._Messages = this._ClientOption.Messages;
            vc.Title = "Messages";
            this.NavigationController.PushViewController(vc, true);
        }

    }
}
