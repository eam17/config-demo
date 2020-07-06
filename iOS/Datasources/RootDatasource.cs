﻿using System;
using System.Reflection;
using AVFoundation;
using ConfigDemo.iOS;
using ConfigDemo.Models;
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
            return null;
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
    }
}