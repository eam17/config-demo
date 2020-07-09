using System;
using ConfigDemo.Models;
using Foundation;
using UIKit;

namespace ConfigDemo.iOS.Datasources
{
    public class FeatureFlagsDatasource : UITableViewSource
    {
        FeatureFlags _Flags;

        public FeatureFlagsDatasource(FeatureFlags flags)
        {
            this._Flags = flags;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            string key = string.Empty;
            string value = string.Empty;

            switch (indexPath.Row)
            {
                case 0:
                    key = "Mobile WA";
                    value = this._Flags.MobileWA?.ToString() ?? "null";
                    break;
                case 1:
                    key = "Promotions";
                    value = this._Flags.Promotions?.ToString() ?? "null";
                    break;
                case 2:
                    key = "Covid-19 Banner";
                    value = this._Flags.Covid19Banner?.ToString() ?? "null";
                    break;
                case 3:
                    key = "Racial Sensitivity Banner";
                    value = this._Flags.RacialSensitivityBanner?.ToString() ?? "null";
                    break;
                case 4:
                    key = "Websockets";
                    value = this._Flags.Websockets?.ToString() ?? "null";
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
            return 5;
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
