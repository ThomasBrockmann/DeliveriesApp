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
    [Activity(Label = "DeliverActivity")]
    public class DeliverActivity : Activity
    {
        Button deliverButton;
        MapFragment mapFragment;

        double lat, lng;
        string deliveryId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Deliver);

            mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.deliverMapFragment);
            deliverButton = FindViewById<Button>(Resource.Id.deliverdButton);
            deliverButton.Click += DeliverButton_Click;

            lat = Intent.GetDoubleExtra("latitude", 0);
            lng = Intent.GetDoubleExtra("longitude", 0);
            deliveryId = Intent.GetStringExtra("deliveryId");

        }

        private async void DeliverButton_Click(object sender, EventArgs e)
        {
            await Delivery.MarkAsDelivered(deliveryId);
        }
    }
}