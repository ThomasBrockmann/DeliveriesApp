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
    //public class DeliveriesFragment : Fragment
    public class DeliveriesFragment : ListFragment
    {
        public async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            var deliveries = await Delivery.GetDeliveries();
            ListAdapter = new DeliveryAdapter(Activity, deliveries);
        }

        //public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //{
        //    // Use this to return your custom view for this Fragment
        //    return inflater.Inflate(Resource.Layout.Deliveries, container, false);
        //}
    }
}