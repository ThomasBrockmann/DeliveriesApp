using DeliveriesApp.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace DerliveryPersonApp.iOS
{
    public partial class WaitingTableViewController : UITableViewController
    {
        List<Delivery> deliveries = new List<Delivery>();

        public WaitingTableViewController (IntPtr handle) : base (handle)
        {
        }
                public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "pickupSegue")
            {
                var selectedRow = TableView.IndexPathForSelectedRow;
                var destinationViewController = segue.DestinationViewController as PickUpViewController;
                destinationViewController.delivery = deliveries[selectedRow.Row];
            }

            base.PrepareForSegue(segue, sender);
        }

    }
}