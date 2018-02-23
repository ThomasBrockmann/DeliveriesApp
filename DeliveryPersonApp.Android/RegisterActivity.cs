using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DeliveriesApp.Model;

namespace DeliveryPersonApp.Android
{
    [Activity(Label = "Register Person")]
    public class RegisterActivity : Activity
    {
        EditText registerEmailEditText, registerPasswordEditText, confirmPasswordEditText;
        Button registerUserButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Register);

            registerEmailEditText = FindViewById<EditText>(Resource.Id.registerEmailEditText);
            registerPasswordEditText = FindViewById<EditText>(Resource.Id.registerPasswordEditText);
            confirmPasswordEditText = FindViewById<EditText>(Resource.Id.confirmPasswordEditText);
            registerUserButton = FindViewById<Button>(Resource.Id.registerUserButton);

            registerUserButton.Click += RegisterUserButton_Click;

            string email = Intent.GetStringExtra("email");
            registerEmailEditText.Text = email;
        }

        private async void RegisterUserButton_Click(object sender, EventArgs e)
        {
            bool result;
            result = await DeliveryPerson.Register(registerEmailEditText.Text, registerPasswordEditText.Text, confirmPasswordEditText.Text);
            if (result)
            {
                Toast.MakeText(this, "Person created.", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "Something went wrong!", ToastLength.Long).Show();
            }
        }
    }
}