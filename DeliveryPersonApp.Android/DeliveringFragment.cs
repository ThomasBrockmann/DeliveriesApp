using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using DeliveriesApp.Model;

namespace DeliveryPersonApp.Android
{
    public class DeliveringFragment : ListFragment
    {
        List<Delivery> deliveries;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

            deliveries = new List<Delivery>();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);

            Delivery selectedDelivery = deliveries[position];

            Intent intent = new Intent(Activity, typeof(DeliverActivity));
            intent.PutExtra("latitude", selectedDelivery.DestinationLatitude);
            intent.PutExtra("longitude", selectedDelivery.DestinationLongitude);
            StartActivity(intent);
        }
    }
}