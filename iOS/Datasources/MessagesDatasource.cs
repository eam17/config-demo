using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace ConfigDemo.iOS.Datasources
{
    public class MessagesDatasource : UITableViewSource
    {
        public List<object> _Messages;

        public MessagesDatasource(List<object> messages)
        {
            this._Messages = messages;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {

            string key = string.Empty;
            string value = string.Empty;

            if(this._Messages.Count == 0)
            {
                key = "No messages";
            }
            else
            {
                key = $"Message: {indexPath.Row + 1}";
                value = this._Messages[indexPath.Row].ToString();
            }
            
            var cell = (PropertyTableViewCell)tableView.DequeueReusableCell(PropertyTableViewCell.Key);
            cell.Bind(key, value);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if (this._Messages.Count == 0)
            {
                return 1;
            }
            return this._Messages.Count;
        }
    }
}
