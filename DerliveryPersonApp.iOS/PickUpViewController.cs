using DeliveriesApp.Model;
using Foundation;
using System;
using UIKit;

namespace DerliveryPersonApp.iOS
{
    public partial class PickUpViewController : UIViewController
    {
        public Delivery delivery;
        public string userId;

        public PickUpViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            pickUpBarButtonItem.Clicked += PickUpBarButtonItem_Clicked;
        }

        private async void PickUpBarButtonItem_Clicked(object sender, EventArgs e)
        {
            await Delivery.MarkAsPickedUp(delivery, userId);
        }
    }
}