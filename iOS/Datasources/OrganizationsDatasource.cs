using System;
using System.Collections.Generic;
using ConfigDemo.Models;
using Foundation;
using UIKit;

namespace ConfigDemo.iOS.Datasources
{
    public class OrganizationsDatasource : UITableViewSource
    {
        public List<Organization> _Org;

        public OrganizationsDatasource(List<Organization> org, OrganizationsViewController view)
        {
            this._Org = org;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var key = string.Empty;
            var value = string.Empty;
            switch (indexPath.Row)
            {
                case 0:
                    key = "Name";
                    value = this._Org[0].Name;
                    break;
                case 1:
                    key = "Program";
                    value = this._Org[0].Program;
                    break;
                case 2:
                    key = "Callback URL";
                    value = this._Org[0].CallbackUrl;
                    break;
                default:
                    break;
            }
            var cell = (PropertyTableViewCell)tableView.DequeueReusableCell(PropertyTableViewCell.Key);
            cell.Bind(key, value);
            cell.BackgroundColor = ChooseColor(indexPath.Row);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 3;
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
