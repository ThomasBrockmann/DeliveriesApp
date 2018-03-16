using CoreLocation;
using DeliveriesApp.Model;
using Foundation;
using MapKit;
using System;
using UIKit;

namespace DerliveryPersonApp.iOS
{
    public partial class PickUpViewController : UIViewController
    {
        public Delivery delivery;
        public string userId;
        CLLocationManager locationManager;

        public PickUpViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            pickUpBarButtonItem.Clicked += PickUpBarButtonItem_Clicked;
            navigateBarButtonItem.Clicked += NavigateBarButtonItem_Clicked;

            PrepareMap();
        }

        private void NavigateBarButtonItem_Clicked(object sender, EventArgs e)
        {
            var coordinates = new CLLocationCoordinate2D(delivery.OriginLatitude, delivery.OriginLongitude);
            var mapItem = new MKMapItem(new MKPlacemark(coordinates));
            mapItem.Name = "Pick up here";
            mapItem.OpenInMaps();
        }

        private void PrepareMap()
        {
            locationManager = new CLLocationManager();
            locationManager.RequestWhenInUseAuthorization();
            pickUpMapView.ShowsUserLocation = true;

            var span = new MKCoordinateSpan(0.15, 0.15);
            var coordinates = new CLLocationCoordinate2D(delivery.OriginLatitude, delivery.OriginLongitude);

            pickUpMapView.Region = new MKCoordinateRegion(coordinates, span);

            pickUpMapView.AddAnnotation(new MKPointAnnotation()
            {
                Title = "Pick up here",
                Coordinate = coordinates
            });
        }

        private async void PickUpBarButtonItem_Clicked(object sender, EventArgs e)
        {
            await Delivery.MarkAsPickedUp(delivery, userId);
        }
    }
}