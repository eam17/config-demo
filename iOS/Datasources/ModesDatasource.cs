using System;
using ConfigDemo.Models;
using Foundation;
using UIKit;

namespace ConfigDemo.iOS.Datasources
{
    public class ModesDatasource : UITableViewSource
    {
        LoginModes _Modes;
        SecondLevelViewController _View;

        bool _IsModes => this._Modes != null;

        public ModesDatasource(LoginModes modes, SecondLevelViewController view)
        {
            this._Modes = modes;
            this._View = view;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var key = "Organizations";
            var cell = (ObjectTableViewCell)tableView.DequeueReusableCell(ObjectTableViewCell.Key);
            cell.Bind(key);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 1;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //this._View.NavigateToOrganizations();
            tableView.DeselectRow(indexPath, true);
        }
    }
}
