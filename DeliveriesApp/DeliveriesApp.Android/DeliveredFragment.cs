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

namespace DeliveriesApp.Droid
{
    public class DeliveredFragment : ListFragment
    {
        public async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

            var delivered = await Delivery.GetDelivered();
            ListAdapter = new ArrayAdapter(Activity, Android.Resource.Layout.SimpleListItem1, delivered);
        }

        //public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //{
        //    base.OnCreateView(inflater, container, savedInstanceState);

        //    // Use this to return your custom view for this Fragment
        //    return inflater.Inflate(Resource.Layout.Delivered, container, false);
        //}
    }
}