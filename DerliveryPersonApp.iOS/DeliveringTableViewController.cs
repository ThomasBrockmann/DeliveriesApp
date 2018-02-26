using DeliveriesApp.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace DerliveryPersonApp.iOS
{
    public partial class DeliveringTableViewController : UITableViewController
    {
        List<Delivery> deliveries = new List<Delivery>();
        public DeliveringTableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "deliverSegue")
            {
                var selectedRow = TableView.IndexPathForSelectedRow;
                var destinationViewController = segue.DestinationViewController as DeliverViewController;
                destinationViewController.delivery = deliveries[selectedRow.Row];
            }

            base.PrepareForSegue(segue, sender);
        }
    }
}