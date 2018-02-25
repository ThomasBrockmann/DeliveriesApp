using DeliveriesApp.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace DeliveriesApp.iOS
{
    public partial class DeliveredViewController : UITableViewController
    {
        List<Delivery> delivered = new List<Delivery>();
        public DeliveredViewController (IntPtr handle) : base (handle)
        {
        }
        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            delivered = await Delivery.GetDelivered();
            TableView.ReloadData();
        }


        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return delivered.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("deliveredCell");

            var delivery = delivered[indexPath.Row];
            cell.TextLabel.Text = delivery.Name??"<null>";
            switch (delivery.Status)
            {
                case 0:
                    cell.DetailTextLabel.Text = "Waiting delivery person";
                    break;
                case 1:
                    cell.DetailTextLabel.Text = "In delivery";
                    break;
                case 2:
                    cell.DetailTextLabel.Text = "delivered";
                    break;
                default:
                    cell.DetailTextLabel.Text = "unknown status";
                    break;
            }
            return cell;
        }

    }
}