using System;
using System.Reflection;
using ConfigDemo.iOS;
using ConfigDemo.Models;
using ConfigDemo.Network;
using Foundation;
using UIKit;

namespace ExampleApp.iOS.Datasource
{
    public class ItemsDatasource : UITableViewSource
    {
        Root _Root;
        PropertyInfo[] _PropList ;

        public ItemsDatasource(Root root)
        {
            this._Root = root;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            //var cell = tableView.DequeueReusableCell("itemCell");
            //this._PropList = this._Root.GetType().GetProperties();
            //var propValue = this._PropList[indexPath.Row].GetValue(this._Root, null).ToString();
            //cell.TextLabel.Text = propValue;
            //return cell;
            if(indexPath.Row < 2)
            {
                return GetObjectCell(tableView, indexPath);
            }
            else
            {
                return GetPropertyCell(tableView, indexPath);
            }
        }

        UITableViewCell GetObjectCell(UITableView tableView, NSIndexPath indexPath)
        {
            string key = string.Empty;
            string value = string.Empty;
            switch (indexPath.Row)
            {
                case 0:
                    key = "LoginModes";
                    value = this._Root.LoginModes.ToString();
                    break;
                case 1:
                    key = "Clients";
                    value = this._Root.Clients.ToString();
                    break;
                default:
                    break;
            }
            value = string.Empty;
            var cell = (ObjectTableViewCell)tableView.DequeueReusableCell(ObjectTableViewCell.Key);
            cell.Bind(key, value);
            return cell;
        }

        UITableViewCell GetPropertyCell(UITableView tableView, NSIndexPath indexPath)
        {
            string key = string.Empty;
            string value = string.Empty;
            switch(indexPath.Row)
            {
                case 2:
                    key = "Is Production";
                    value = this._Root.IsProduction.ToString();
                    break;
                case 3:
                    key = "ApiDomain";
                    value = this._Root.ApiDomain;
                    break;
                case 4:
                    key = "PingOneLogoutUrl";
                    value = this._Root.PingOneLogoutUrl;
                    break;
                case 5:
                    key = "Version";
                    value = this._Root.Version;
                    break;
                default:
                    break;
            }

           var cell = (PropertyTableViewCell)tableView.DequeueReusableCell(PropertyTableViewCell.Key);
           cell.Bind(key, value);
           return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 6;
        }
        public PropertyInfo GetItem(int row)
        {
            return this._PropList[row];
        }
    }
}
