using Foundation;
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

            var waitingVC = ViewControllers[0] as WaitingTableViewController;
            waitingVC.userId = userId;
            var deliveringVC = ViewControllers[1] as DeliveringTableViewController;
            deliveringVC.userId = userId;
            var deliveredVC = ViewControllers[2] as DeliveredTableViewController;
            deliveredVC.userId = userId;
        }
    }
}