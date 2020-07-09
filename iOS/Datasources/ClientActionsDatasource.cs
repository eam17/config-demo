using System;
using ConfigDemo.Models;
using Foundation;
using UIKit;

namespace ConfigDemo.iOS.Datasources
{
    public class ClientActionsDatasource : UITableViewSource
    {
        ClientActions _Action;

        public ClientActionsDatasource(ClientActions action)
        {
            this._Action = action;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            string key = "Purge Local";
            string value = this._Action.PurgeLocal?.ToString() ?? "null";

            var cell = (PropertyTableViewCell)tableView.DequeueReusableCell(PropertyTableViewCell.Key);
            cell.Bind(key, value);
            cell.BackgroundColor = ChooseColor(indexPath.Row);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 1;
        }

        UIColor ChooseColor(int row)
        {
            if (row % 2 == 0)
            {
                return UIColor.FromName("color-dark-2");
            }
            else
            {
                return UIColor.FromName("color-dark-1");
            }
        }
    }
}
