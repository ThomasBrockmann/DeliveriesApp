// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace DerliveryPersonApp.iOS
{
    [Register ("PickUpViewController")]
    partial class PickUpViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem navigateBarButtonItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem pickUpBarButtonItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView pickUpMapView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (navigateBarButtonItem != null) {
                navigateBarButtonItem.Dispose ();
                navigateBarButtonItem = null;
            }

            if (pickUpBarButtonItem != null) {
                pickUpBarButtonItem.Dispose ();
                pickUpBarButtonItem = null;
            }

            if (pickUpMapView != null) {
                pickUpMapView.Dispose ();
                pickUpMapView = null;
            }
        }
    }
}