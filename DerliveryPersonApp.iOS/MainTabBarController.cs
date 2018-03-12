﻿using Foundation;
using System;
using UIKit;

namespace DerliveryPersonApp.iOS
{
    public partial class MainTabBarController : UITabBarController
    {
        public string userId;

        public MainTabBarController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            NavigationItem.SetHidesBackButton(true, false);
        }
    }
}