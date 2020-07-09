using System;
using System.Reflection;
using AVFoundation;
using ConfigDemo.iOS;
using ConfigDemo.Models;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace ExampleApp.iOS.Datasource
{
    public class RootDatasource : UITableViewSource
    {
        Root _Root;

        bool _IsRoot => this._Root != null;

        ViewController _View;


        public RootDatasource(Root root, ViewController view)
        {
            this._Root = root;
            this._View = view;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
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

        UITableViewCell GetObjectCell(UITableView tableView, NSIndexPath indexPath)
        {
            string key = string.Empty;
            if (this._IsRoot)
            {
                switch (indexPath.Row)
                {
                    case 0:
                        key = "LoginModes";
                        break;
                    case 1:
                        key = "Clients";
                        break;
                    default:
                        break;
                }
            }

            var cell = (ObjectTableViewCell)tableView.DequeueReusableCell(ObjectTableViewCell.Key);

            cell.Bind(key);
            cell.BackgroundColor = ChooseColor(indexPath.Row);

            

            return cell;
        }

        UITableViewCell GetPropertyCell(UITableView tableView, NSIndexPath indexPath)
        {
            string key = string.Empty;
            string value = string.Empty;

            var cell = (PropertyTableViewCell)tableView.DequeueReusableCell(PropertyTableViewCell.Key);

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
            cell.Bind(key, value);
            cell.BackgroundColor = ChooseColor(indexPath.Row);

            //var gradientLayer = new CAGradientLayer();
            //gradientLayer.Colors = new[] { UIColor.Red.CGColor, UIColor.Blue.CGColor };
            //gradientLayer.Locations = new NSNumber[] { 0, 1 };

            //var rect = new CGRect(0, 0, 543, cell.IntrinsicContentSize.Height);
            //gradientLayer.Frame = rect;
            //gradientLayer.Opacity = 0.5f;

            ////this.TableView.BackgroundColor = UIColor.Clear;
            //cell.Layer.AddSublayer(gradientLayer);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 6;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //row tapped
            switch (indexPath.Row)
            {
                case 0:
                    this._View.NavigateToLoginModes();
                    break;
                case 1:
                    this._View.NavigateToClients();
                    break;
                default:
                    break;
            }

            tableView.DeselectRow(indexPath, true);
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
