using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Microsoft.WindowsAzure.MobileServices;
using DeliveriesApp.Model;
using Android.Runtime;
using Android.Util;

namespace DeliveriesApp.Droid
{
    [Activity(Label = "DeliveriesApp", MainLauncher = true, Icon = "@mipmap/truck_blue")]
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
                Log.Info("myApp", "Benutzer angemeldet");
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
            StartActivityForResult(intent, 1);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                string eMail = data.GetStringExtra("returnemail");
                if (!string.IsNullOrEmpty(eMail))
                {
                    Log.Info("OnActivityResult", "Alles gut" + eMail);
                    emailEditText.Text = eMail;
                }
                else Log.Info("OnActivityResult", "Uebergabe leer oder Null");
            }
        }
    }
}

