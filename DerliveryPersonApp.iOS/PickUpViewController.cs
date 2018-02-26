using DeliveriesApp.Model;
using Foundation;
using System;
using UIKit;

namespace DerliveryPersonApp.iOS
{
    public partial class PickUpViewController : UIViewController
    {
        public Delivery delivery;

        public PickUpViewController (IntPtr handle) : base (handle)
        {
        }
    }
}