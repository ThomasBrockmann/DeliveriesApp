﻿// WARNING
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
    [Register ("DeliverViewController")]
    partial class DeliverViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem deliverBarButtonItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView deliveringMapView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint deliveryMapView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem navigateBarButtonItem { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (deliverBarButtonItem != null) {
                deliverBarButtonItem.Dispose ();
                deliverBarButtonItem = null;
            }

            if (deliveringMapView != null) {
                deliveringMapView.Dispose ();
                deliveringMapView = null;
            }

            if (deliveryMapView != null) {
                deliveryMapView.Dispose ();
                deliveryMapView = null;
            }

            if (navigateBarButtonItem != null) {
                navigateBarButtonItem.Dispose ();
                navigateBarButtonItem = null;
            }
        }
    }
}