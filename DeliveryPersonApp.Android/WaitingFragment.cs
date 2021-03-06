﻿using System;
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
    public class WaitingFragment : ListFragment
    {
        List<Delivery> deliveries;
        public async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            string personId = (Activity as TabsActivity).PersonId;
            deliveries = await Delivery.GetWaiting();
            ListAdapter = new ArrayAdapter(Activity, global::Android.Resource.Layout.SimpleListItem1, deliveries);
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

            Intent intent = new Intent(Activity, typeof(PickUpActivity));
            intent.PutExtra("latitude", selectedDelivery.DestinationLatitude);
            intent.PutExtra("longitude", selectedDelivery.DestinationLongitude);
            intent.PutExtra("personId", (Activity as TabsActivity).PersonId);
            intent.PutExtra("deliveryId", selectedDelivery.Id);
            StartActivity(intent);
        }

    }
}