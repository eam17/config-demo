using System;
using System.Collections.Generic;
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

        ViewController _View;

        List<(string Key, object Value)> _ItemsList;

        public RootDatasource(List<(string Key, object Value)> items, ViewController view)
        {
            this._ItemsList = items;
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

            key = this._ItemsList[indexPath.Row].Key;


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

            key = this._ItemsList[indexPath.Row].Key;
            value = this._ItemsList[indexPath.Row].Value.ToString();

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
