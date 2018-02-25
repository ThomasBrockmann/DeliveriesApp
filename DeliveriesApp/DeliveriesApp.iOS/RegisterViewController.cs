using DeliveriesApp.Model;
using Foundation;
using System;
using UIKit;

namespace DeliveriesApp.iOS
{
    public partial class RegisterViewController : UIViewController
    {
        public string emailAddress;

        public RegisterViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            emailTextField.Text = emailAddress;
            registerButton.TouchUpInside += RegisterButton_TouchUpInside1;
        }

        private async void RegisterButton_TouchUpInside1(object sender, EventArgs e)
        {
            bool result;
            result = await User.Register(emailTextField.Text, passwordTextField.Text, confirmpasswordTextField.Text);
            if (result)
            {
                //Intent intent = new Intent(this, typeof(MainActivity));
                //intent.PutExtra("returnemail", registerEmailEditText.Text);
                //SetResult(Result.Ok, intent);
                var alert = UIAlertController.Create("Success", "User registered successfully", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(alert, true, null);
                return;

                //Finish();
            }
            else
            {
                var alert = UIAlertController.Create("Error", "Something went wrong!", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(alert, true, null);
                return;
            }
        }
    }
}