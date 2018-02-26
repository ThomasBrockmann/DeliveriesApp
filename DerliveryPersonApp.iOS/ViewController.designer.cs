// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace DerliveryPersonApp.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField emailTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton loginButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField passwordTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton registerButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (emailTextField != null) {
                emailTextField.Dispose ();
                emailTextField = null;
            }

            if (loginButton != null) {
                loginButton.Dispose ();
                loginButton = null;
            }

            if (passwordTextField != null) {
                passwordTextField.Dispose ();
                passwordTextField = null;
            }

            if (registerButton != null) {
                registerButton.Dispose ();
                registerButton = null;
            }
        }
    }
}