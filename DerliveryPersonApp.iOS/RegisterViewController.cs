using DeliveriesApp.Model;
using Foundation;
using System;
using UIKit;

namespace DerliveryPersonApp.iOS
{
    public partial class RegisterViewController : UIViewController
    {
        public RegisterViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            registerButton.TouchUpInside += RegisterButton_TouchUpInside;
        }

        private async void RegisterButton_TouchUpInside(object sender, EventArgs e)
        {
            bool success = await DeliveryPerson.Register(emailTextField.Text, passwordTextField.Text, confirmPasswordTextField.Text);
            UIAlertController alert = null;
            if (success)
            {
                alert = UIAlertController.Create("Success", "You was registered successfully.", UIAlertControllerStyle.Alert);
            }
            else
            {
                alert = UIAlertController.Create("Error", "Something went wrong.", UIAlertControllerStyle.Alert);
            }
            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }
    }
}