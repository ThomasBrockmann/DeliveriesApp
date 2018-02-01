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

namespace DeliveriesApp.Droid
{
    [Activity(Label = "NewDeliveryActivity")]
    public class NewDeliveryActivity : Activity
    {
        Button SaveButton;
        EditText packageNameEditText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.NewDelivery);

            SaveButton = FindViewById<Button>(Resource.Id.SaveButton);
            packageNameEditText = FindViewById<EditText>(Resource.Id.packageNameEditText);
            SaveButton.Click += SaveButton_Click;
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery();
            delivery.Name = packageNameEditText.Text;
            delivery.Status = 0;
            await Delivery.InsertDelivery(delivery);
        }
    }
}