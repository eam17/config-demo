using System;
using System.Collections.Generic;
using ConfigDemo.Models;
using Foundation;
using UIKit;

namespace ConfigDemo.iOS.Datasources
{
    public class ClientOptionDatasource : UITableViewSource
    {
        ClientObject _ClientOption;
        ClientOptionViewController _View;

        public ClientOptionDatasource(ClientObject options, ClientOptionViewController view)
        {
            this._ClientOption = options;
            this._View = view;
            this._ClientOption.Messages = new List<object> { "One", "Two", "Three", "Four", "Five" };
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            if (indexPath.Row < 3)
            {
                return GetPropertyCell(tableView, indexPath);
            }
            else
            {
                return GetObjectCell(tableView, indexPath);
            }
        }

        

        UITableViewCell GetPropertyCell(UITableView tableView, NSIndexPath indexPath)
        {
            string key = string.Empty;
            string value = string.Empty;

            switch (indexPath.Row)
            {
                case 0:
                    key = "Analytics Tracking Code";
                    value = this._ClientOption.AnalyticsTrackingCode;
                    break;
                case 1:
                    key = "Minimum Version";
                    value = this._ClientOption.MinimumVersion ?? "null";
                    break;
                case 2:
                    key = "Current Version";
                    value = this._ClientOption.CurrentVersion ?? "null";
                    break;
                default:
                    break;
            }

            var cell = (PropertyTableViewCell)tableView.DequeueReusableCell(PropertyTableViewCell.Key);
            cell.Bind(key, value);
            return cell;
        }

        UITableViewCell GetObjectCell(UITableView tableView, NSIndexPath indexPath)
        {
            string key = string.Empty;

            var cell = (ObjectTableViewCell)tableView.DequeueReusableCell(ObjectTableViewCell.Key);

            switch (indexPath.Row)
            {
                case 3:
                    key = "Client Actions";
                    break;
                case 4:
                    key = "Feature Flags";
                    break;
                case 5:
                    key = "Messages";
                    if (this._ClientOption.Messages.Count == 0)
                    {
                        cell.Accessory = UIKit.UITableViewCellAccessory.None;
                    }
                    break;
                default:
                    break;
            }
            cell.Bind(key);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 6;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            switch (indexPath.Row)
            {
                case 3:
                    this._View.NavigateToClientActions();
                    break;
                case 4:
                    this._View.NavigateToFeatureFlags();
                    break;
                case 5:
                    if (this._ClientOption.Messages.Count == 0)
                    {
                        var alert = new UIAlertView("Alert", "No messages to display", null, "OK", null);
                        alert.Show();
                    }
                    else
                    {
                        this._View.NavigateToMessages();
                    }
                    break;
                default:
                    break;
            }
            
            tableView.DeselectRow(indexPath, true);
        }
    }
}
