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

namespace DeliveriesApp.Droid
{
    [Activity(Label = "TabsActivity")]
    public class TabsActivity : Activity
    {
        Toolbar tabsToolbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Tabs);

            tabsToolbar = FindViewById<Toolbar>(Resource.Id.toolbar_bottom);
            tabsToolbar.InflateMenu(Resource.Menu.tabsMenu);
            tabsToolbar.MenuItemClick += TabsToolbar_MenuItemClick;

            //var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //SetActionBar(toolbar);
            //ActionBar.Title = "-Deliveries-";

            //tabsToolbar = FindViewById<Toolbar>(Resource.Id.toolbar_bottom);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            AddTab("Deliveries", 0, new DeliveriesFragment());
            AddTab("Delivered", 0, new DeliveredFragment());
            AddTab("Profile", 0, new ProfileFragment());
        }

        private void TabsToolbar_MenuItemClick(object sender, Toolbar.MenuItemClickEventArgs e)
        {
            Toast.MakeText(this, "ActionBar pressed: " + e.Item.TitleFormatted, ToastLength.Short).Show();
            if (e.Item.ItemId == Resource.Id.menu_add)
            {
                StartActivity(typeof(NewDeliveryActivity));
            }
        }
        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.Menu.tabsMenu, menu);
        //    return base.OnCreateOptionsMenu(menu);
        //}
        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    if (item.ItemId == Resource.Id.menu_add)
        //    {
        //        StartActivity(typeof(NewDeliveryActivity));
        //    }
        //    else
        //    {
        //        Toast.MakeText(this, "Top ActionBar pressed: " + item.TitleFormatted, ToastLength.Short).Show();
        //    }
        //    return base.OnOptionsItemSelected(item);
        //}

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