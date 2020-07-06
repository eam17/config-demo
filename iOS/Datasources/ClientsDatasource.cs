using System;
using ConfigDemo.Models;
using Foundation;
using UIKit;

namespace ConfigDemo.iOS.Datasources
{
    public class ClientsDatasource : UITableViewSource
    {
        Clients _Clients;
        SecondLevelViewController _View;

        bool _IsClients => this._Clients != null;

        public ClientsDatasource(Clients clients, SecondLevelViewController view)
        {
            this._Clients = clients;
            this._View = view;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var key = string.Empty;
            switch (indexPath.Row)
            {
                case 0:
                    key = "Web";
                    break;
                case 1:
                    key = "Android";
                    break;
                case 2:
                    key = "iOS";
                    break;
                default:
                    break;
            }
            var cell = (ObjectTableViewCell)tableView.DequeueReusableCell(ObjectTableViewCell.Key);
            cell.Bind(key);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 3;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            this._View.NavigateToClientOption(indexPath.Row);
            tableView.DeselectRow(indexPath, true);
        }
    }
}
