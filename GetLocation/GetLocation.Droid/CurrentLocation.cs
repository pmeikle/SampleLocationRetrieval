using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using GetLocation.Droid;
using Xamarin.Forms;
using Xamarin.Geolocation;

[assembly: Xamarin.Forms.Dependency (typeof (CurrentLocation))]
namespace GetLocation.Droid
{
    public class CurrentLocation : Activity, ICurrentLocation
    {
        Location currentLocation;
        LocationManager locationManager;
        TextView locationText;
        TextView addressText;
        string locationProvider;


        public CurrentLocation() { }

        public async Task<GPSCoordinates> GetCurrentCoordinates()
        {
            var locator = new Geolocator(Forms.Context) {DesiredAccuracy = 50};
            var coordinates = new GPSCoordinates();
            if(locator.IsGeolocationEnabled && locator.IsGeolocationEnabled)
            {
                var pos = await locator.GetPositionAsync(timeout: 10000);
                coordinates.Latitude = pos.Latitude;
                coordinates.Longitude = pos.Longitude;
            }

            return coordinates;
        }
    }
}