using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GetLocation.iOS;
using Xamarin.Forms;
using Xamarin.Geolocation;

[assembly: Xamarin.Forms.Dependency (typeof (CurrentLocation))]
namespace GetLocation.iOS
{
    class CurrentLocation : ICurrentLocation
    {
        public async Task<GPSCoordinates> GetCurrentCoordinates()
        {
            var locator = new Geolocator() { DesiredAccuracy = 50 };
            var coordinates = new GPSCoordinates();
            if (locator.IsGeolocationEnabled && locator.IsGeolocationEnabled)
            {
                var pos = await locator.GetPositionAsync(timeout: 10000);
                coordinates.Latitude = pos.Latitude;
                coordinates.Longitude = pos.Longitude;
            }

            return coordinates;
        }
    }
}
