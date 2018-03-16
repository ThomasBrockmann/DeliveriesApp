using CoreLocation;
using DeliveriesApp.Model;
using Foundation;
using MapKit;
using System;
using UIKit;

namespace DerliveryPersonApp.iOS
{
    public partial class DeliverViewController : UIViewController
    {
        public Delivery delivery;
        CLLocationManager locationManager;

        public DeliverViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            deliverBarButtonItem.Clicked += DeliverBarButtonItem_Clicked;
            navigateBarButtonItem.Clicked += NavigateBarButtonItem_Clicked;

            PrepareMap();
        }

        private void NavigateBarButtonItem_Clicked(object sender, EventArgs e)
        {
            var coordinates = new CLLocationCoordinate2D(delivery.DestinationLatitude, delivery.DestinationLongitude);
            var mapItem = new MKMapItem(new MKPlacemark(coordinates));
            mapItem.Name = "Deliver here";
            mapItem.OpenInMaps();
        }

        private void PrepareMap()
        {
            locationManager = new CLLocationManager();
            locationManager.RequestWhenInUseAuthorization();
            deliveringMapView.ShowsUserLocation = true;

            var span = new MKCoordinateSpan(0.15, 0.15);
            var coordinates = new CLLocationCoordinate2D(delivery.DestinationLatitude, delivery.DestinationLongitude);

            deliveringMapView.Region = new MKCoordinateRegion(coordinates, span);

            deliveringMapView.AddAnnotation(new MKPointAnnotation()
            {
                Title = "Dliver Here",
                Coordinate = coordinates
            });
        }

        private async void DeliverBarButtonItem_Clicked(object sender, EventArgs e)
        {
            await Delivery.MarkAsDelivered(delivery);
        }
    }
}