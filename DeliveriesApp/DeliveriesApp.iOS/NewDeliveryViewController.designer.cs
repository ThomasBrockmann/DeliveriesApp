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
        UIKit.UITextField packeNameTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem saveBarButtonItem { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (packeNameTextField != null) {
                packeNameTextField.Dispose ();
                packeNameTextField = null;
            }

            if (saveBarButtonItem != null) {
                saveBarButtonItem.Dispose ();
                saveBarButtonItem = null;
            }
        }
    }
}