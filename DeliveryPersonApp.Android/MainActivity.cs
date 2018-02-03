using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using DeliveriesApp.Model;

namespace DeliveryPersonApp.Android
{
    [Activity(Label = "DeliveriesApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        EditText emailEditText, passwordEditText;
        Button signinButton, registerButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            signinButton = FindViewById<Button>(Resource.Id.signinButton);
            registerButton = FindViewById<Button>(Resource.Id.registerButton);

            registerButton.Click += RegisterButton_Click;
            signinButton.Click += SigninButton_Click;
        }

        private async void SigninButton_Click(object sender, System.EventArgs e)
        {
            bool result;
            result = await User.Login(emailEditText.Text, passwordEditText.Text);
            if (result)
            {
                Intent intent = new Intent(this, typeof(TabsActivity));
                StartActivity(intent);
                Finish();
            }
            else
            {
                Toast.MakeText(this, "Try again later", ToastLength.Long).Show();
            }
        }

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(RegisterActivity));
            intent.PutExtra("email", emailEditText.Text);
            StartActivity(intent);
        }
    }
}


