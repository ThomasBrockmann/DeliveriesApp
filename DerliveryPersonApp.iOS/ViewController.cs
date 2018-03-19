using DeliveriesApp.Model;
using Foundation;
using System;

using UIKit;

namespace DerliveryPersonApp.iOS
{
    public partial class ViewController : UIViewController
    {
        string userId = string.Empty;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            loginButton.TouchUpInside += LoginButton_TouchUpInside;
        }

        private async void LoginButton_TouchUpInside(object sender, EventArgs e)
        {
            userId = await DeliveryPerson.Login(emailTextField.Text, passwordTextField.Text);
            if (string.IsNullOrEmpty(userId))
            {
                UIAlertController alert = null;
                alert = UIAlertController.Create("Error", "Something went wrong.", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(alert, true, null);
            }
            else
            {
                PerformSegue("loginSegue", this);
            }
        }

        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            if (segueIdentifier == "loginSegue")
            {
                return !string.IsNullOrEmpty(userId);
            }
            return base.ShouldPerformSegue(segueIdentifier, sender);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "loginSegue")
            {
                var destinationVC = segue.DestinationViewController as MainTabBarController;
                destinationVC.userId = userId;
            }
            base.PrepareForSegue(segue, sender);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}