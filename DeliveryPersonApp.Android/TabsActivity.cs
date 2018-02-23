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

namespace DeliveryPersonApp.Android
{
    [Activity(Label = "Overview Deliveries")]
    public class TabsActivity : Activity
    {
        private string personId;

        public string PersonId
        {
            get { return personId; }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Tabs);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            AddTab("Delivering", 0, new DeliveringFragment());
            AddTab("Waiting", 0, new WaitingFragment());
            AddTab("Delivered", 0, new DeliveredFragment());

            personId = Intent.GetStringExtra("personId");
        }


        private void AddTab(string title, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(title);
            //tab.SetIcon(iconResourceId);

            // must set event handler before adding tab
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };
            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e) {
                e.FragmentTransaction.Remove(view);
            };

            this.ActionBar.AddTab(tab);
        }

    }
}