using System;
using DeliveriesApp.Model;
using Foundation;
using UIKit;

namespace DeliveriesApp.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.

            signInButton.TouchUpInside += SignInButton_TouchUpInside;

        }

        private async void SignInButton_TouchUpInside(object sender, EventArgs e)
        {
            bool result;
            result = await User.Login(emailTextField.Text, passwordTextField.Text);
            if (result)
            {
                var alert = UIAlertController.Create("Success", "You are logged in!!!", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(alert, true, null);

                //Intent intent = new Intent(this, typeof(TabsActivity));
                //StartActivity(intent);
                //Finish();
            }
            else
            {
                var alert = UIAlertController.Create("Error", "Log in not successful", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(alert, true, null);
            }
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if(segue.Identifier == "registerSegue")
            {
                var destinatioViewController = segue.DestinationViewController as RegisterViewController;
                destinatioViewController.emailAddress = emailTextField.Text;
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

    }
}
