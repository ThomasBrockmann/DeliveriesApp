﻿using DeliveriesApp.Model;
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
    }
}