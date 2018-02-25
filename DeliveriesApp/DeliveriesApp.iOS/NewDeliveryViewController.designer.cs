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

namespace DeliveriesApp.iOS
{
    [Register ("NewDeliveryViewController")]
    partial class NewDeliveryViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel deliverToLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView destinationMapView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView originMapView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField packeNameTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel pickUpLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem saveBarButtonItem { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (deliverToLabel != null) {
                deliverToLabel.Dispose ();
                deliverToLabel = null;
            }

            if (destinationMapView != null) {
                destinationMapView.Dispose ();
                destinationMapView = null;
            }

            if (originMapView != null) {
                originMapView.Dispose ();
                originMapView = null;
            }

            if (packeNameTextField != null) {
                packeNameTextField.Dispose ();
                packeNameTextField = null;
            }

            if (pickUpLabel != null) {
                pickUpLabel.Dispose ();
                pickUpLabel = null;
            }

            if (saveBarButtonItem != null) {
                saveBarButtonItem.Dispose ();
                saveBarButtonItem = null;
            }
        }
    }
}