using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DeliveriesApp.Model;

namespace DeliveryPersonApp.Android
{
    [Activity(Label = "PickUpActivity")]
    public class PickUpActivity : Activity

    {
        MapFragment mapFragment;
        Button pickUpButton;
        double lat, lng;
        string personId, deliveryId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.PickUp);
            mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.pickupMapFragment);
            pickUpButton = FindViewById<Button>(Resource.Id.pickUpButton);
            pickUpButton.Click += PickUpButton_Click;

            lat = Intent.GetDoubleExtra("latitude", 0);
            lng = Intent.GetDoubleExtra("longitude", 0);
            personId = Intent.GetStringExtra("personId");
            deliveryId = Intent.GetStringExtra("deliveryId");

        }

        private async void PickUpButton_Click(object sender, EventArgs e)
        {
            await Delivery.MarkAsPickedUp(deliveryId, personId);
        }
    }
}