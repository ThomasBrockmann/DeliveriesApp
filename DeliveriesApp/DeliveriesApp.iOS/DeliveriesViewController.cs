using DeliveriesApp.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace DeliveriesApp.iOS
{
    public partial class DeliveriesViewController : UITableViewController
    {
        List<Delivery> deliveries;
        public DeliveriesViewController (IntPtr handle) : base (handle)
        {
        }
        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            deliveries = await Delivery.GetDeliveries();
        }
    }
}