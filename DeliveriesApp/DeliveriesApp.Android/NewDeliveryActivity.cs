using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DeliveriesApp.Model;

namespace DeliveriesApp.Droid
{
    [Activity(Label = "NewDeliveryActivity")]
    public class NewDeliveryActivity : Activity, IOnMapReadyCallback, ILocationListener
    {
        Button SaveButton;
        EditText packageNameEditText;
        MapFragment mapFragment;
        double latitude;
        double longitude;
        LocationManager locationManager;

        public void OnLocationChanged(Location location)
        {
            latitude = location.Latitude;
            longitude = location.Longitude;
            mapFragment.GetMapAsync(this);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            MarkerOptions marker = new MarkerOptions();
            marker.SetPosition(new LatLng(latitude, longitude));
            marker.SetTitle("Your location");
            googleMap.AddMarker(marker);
        }

        public void OnProviderDisabled(string provider)
        {
            
        }

        public void OnProviderEnabled(string provider)
        {
            
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.NewDelivery);

            SaveButton = FindViewById<Button>(Resource.Id.SaveButton);
            packageNameEditText = FindViewById<EditText>(Resource.Id.packageNameEditText);
            mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.mapFragment);
            //mapFragment.GetMapAsync(this);

            SaveButton.Click += SaveButton_Click;

        }

        protected override void OnResume()
        {
            base.OnResume();

            locationManager = GetSystemService(Context.LocationService) as LocationManager;
            string provider = LocationManager.GpsProvider;

            if (locationManager.IsProviderEnabled(provider))
            {
                locationManager.RequestLocationUpdates(provider, 5000, 1, this);
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            locationManager.RemoveUpdates(this);
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