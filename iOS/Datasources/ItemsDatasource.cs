using System;
using System.Reflection;
using AVFoundation;
using ConfigDemo.iOS;
using ConfigDemo.Models;
using Foundation;
using UIKit;

namespace ExampleApp.iOS.Datasource
{
    public class ItemsDatasource : UITableViewSource
    {
        Root _Root;
        PropertyInfo[] _PropList;
        LoginModes _Modes;
        Clients _Clients;
        bool _IsRoot => this._Root != null;
        bool _IsModes => this._Modes != null;
        bool _IsClients => this._Clients != null;

        int _RowNumber;

        ViewController _View;
        public ItemsDatasource(Root root, ViewController view)
        {
            this._Root = root;
            this._RowNumber = 6;
            this._View = view;
        }

        public ItemsDatasource(LoginModes modes, ViewController view)
        {
            this._Modes = modes;
            this._RowNumber = 1;
            this._View = view;
        }

        public ItemsDatasource(Clients clients, ViewController view)
        {
            this._Clients = clients;
            this._RowNumber = 3;
            this._View = view;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            //var cell = tableView.DequeueReusableCell("itemCell");
            //this._PropList = this._Root.GetType().GetProperties();
            //var propValue = this._PropList[indexPath.Row].GetValue(this._Root, null).ToString();
            //cell.TextLabel.Text = propValue;
            //return cell;
            if (this._IsRoot == true)
            {
                if (indexPath.Row < 2)
                {
                    return GetObjectCell(tableView, indexPath);
                }
                else
                {
                    return GetPropertyCell(tableView, indexPath);
                }
            }
            else if (this._IsModes)
            {
                return GetObjectCell(tableView, indexPath);
            }
            else if (this._IsClients)
            {
                return GetObjectCell(tableView, indexPath);
            }
            return null;
        }

        //public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        //{
        //    return base.GetHeightForRow(tableView, indexPath);
        //}

        UITableViewCell GetObjectCell(UITableView tableView, NSIndexPath indexPath)
        {
            string key = string.Empty;
            string value = string.Empty;
            if (this._IsRoot)
            {
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
            }
            else if (this._IsModes)
            {
                key = "Organizations";
                value = this._Modes.Organizations.ToString();
            }
            else if (this._IsClients)
            {

                key = "Organizations";
                value = this._Modes.Organizations.ToString();
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

            switch (indexPath.Row)
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
            return this._RowNumber;
        }
        public PropertyInfo GetItem(int row)
        {
            return this._PropList[row];
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //row tapped
            this._View.NavigateToSecongLevel();
            // this._View.PresentViewController(okAlertController, true, null);

            tableView.DeselectRow(indexPath, true);
        }
    }
}
