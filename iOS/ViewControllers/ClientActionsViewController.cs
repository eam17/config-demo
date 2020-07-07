// This file has been autogenerated from a class added in the UI designer.

using System;
using ConfigDemo.iOS.Datasources;
using ConfigDemo.Models;
using Foundation;
using UIKit;

namespace ConfigDemo.iOS
{
	public partial class ClientActionsViewController : UITableViewController
	{

        public ClientActions _Action;
        bool _IsAction => this._Action != null;

        public ClientActionsViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.TableView.RegisterNibForCellReuse(PropertyTableViewCell.Nib, PropertyTableViewCell.Key);
            this.TableView.RowHeight = UITableView.AutomaticDimension;
            this.TableView.EstimatedRowHeight = 44;
            this.TableView.TableFooterView = new UIView();

            if (this._IsAction)
            {
                GetClientActions();
            }

        }

        void GetClientActions()
        {
            var source = new ClientActionsDatasource(this._Action);
            this.TableView.Source = source;
            this.TableView.ReloadData();
        }
    }
}