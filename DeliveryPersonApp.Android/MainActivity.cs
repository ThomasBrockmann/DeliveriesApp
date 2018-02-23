using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using DeliveriesApp.Model;

namespace DeliveryPersonApp.Android
{
    [Activity(Label = "Delivery Person", MainLauncher = true, Icon = "@mipmap/truck_green")]
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

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(RegisterActivity));
            intent.PutExtra("email", emailEditText.Text);
            StartActivity(intent);
        }

        private async void SigninButton_Click(object sender, System.EventArgs e)
        {
            string personId;
            personId = await DeliveryPerson.Login(emailEditText.Text, passwordEditText.Text);
            if (!string.IsNullOrEmpty(personId))
            {
                Intent intent = new Intent(this, typeof(TabsActivity));
                intent.PutExtra("personId", personId);
                Toast.MakeText(this, "Person: " + personId, ToastLength.Long).Show();
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(this, "no Person found.", ToastLength.Long).Show();
            }
        }
    }
}


