using DeliveriesApp.Model;
using Foundation;
using System;
using UIKit;

namespace DerliveryPersonApp.iOS
{
    public partial class DeliverViewController : UIViewController
    {
        public Delivery delivery;

        public DeliverViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            deliverBarButtonItem.Clicked += DeliverBarButtonItem_Clicked;
        }

        private async void DeliverBarButtonItem_Clicked(object sender, EventArgs e)
        {
            await Delivery.MarkAsDelivered(delivery);
        }
    }
}