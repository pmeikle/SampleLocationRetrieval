using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GetLocation
{
    public class App : Application
    {
        private ICurrentLocation CurrentLocation;

        public App()
        {
            CurrentLocation = DependencyService.Get<ICurrentLocation>();
            var label = new Label {
                XAlign = TextAlignment.Center,
                //Text = "Long: " + okay.Result.Longitude + " Lat: " + okay.Result.Latitude,
                Text ="Helo",
            };
            var button = new Button() {Text="Click me"};
            button.Clicked += async (s, e) =>
            {
                var temp = await DoSomething();
                label.Text = "Clicked, long: " + temp.Longitude + " lat: " + temp.Latitude;
            };
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        label, button
                    }
                }
            };
        }

        private async Task<GPSCoordinates> DoSomething()
        {
            var pos = await CurrentLocation.GetCurrentCoordinates();
            return pos;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
