using System;

using Android.App;
using Android.Content.PM;
using Android.Widget;
using Android.OS;
using Android.Locations;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Android.Content;
using Xamarin.Forms.PlatformConfiguration;

namespace ToDoActivity.Droid
{
    [Activity(Label = "ToDoActivity.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        // All variable declared here
        static readonly string TAG = "X:" + typeof(MainActivity).Name;
        string _locationProvider;
        int WIFI_SETTINGS_REQ_CODE = 100;
        const int RequestLocationId = 0;

        readonly string[] PermissionsLocation =
            {
                Manifest.Permission.AccessCoarseLocation,
                Manifest.Permission.AccessFineLocation
            };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Forms.Init(this, savedInstanceState);

            CheckForGPSSettings();
            LoadApplication(new App());
        }

        // To check if Wifi is available from any mode either from GPS or Wifi
        private void CheckForGPSSettings()
        {
            Boolean gps_enabled = false;
            Boolean network_enabled = false;

            LocationManager _locationManager = (LocationManager)GetSystemService(LocationService);
            try
            {
                gps_enabled = _locationManager.IsProviderEnabled(LocationManager.GpsProvider);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "Error in GPS = " + ex.Message, ToastLength.Long).Show();
            }

            try
            {
                network_enabled = _locationManager.IsProviderEnabled(LocationManager.NetworkProvider);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "Error in Network = " + ex.Message, ToastLength.Long).Show();
            }

            if (!gps_enabled)
            {
                var intent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
                StartActivityForResult(intent, WIFI_SETTINGS_REQ_CODE);
            }
            else
            {
                SetUpLocationServicesAsync();
            }
        }

        //When User come back from the GPS Setting screen, need to initiate GPS stuff
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == WIFI_SETTINGS_REQ_CODE)
                CheckForGPSSettings();
        }

        // Prior to fetching current location
        private async void SetUpLocationServicesAsync()
        {
            await TryGetLocationAsync();
        }

        // Checking for devive version as marshmallow and above device require permission to be granted
        async Task TryGetLocationAsync()
        {
            if ((int)Build.VERSION.SdkInt < 23)
            {
                await GetLocationAsync();
                return;
            }
            await GetLocationPermissionAsync();
        }

        // For marshmallow and above devices It is required to ask for the GPS permission. allow or deny are the options.
        async Task GetLocationPermissionAsync()
        {
            const string permission = Manifest.Permission.AccessFineLocation;

            if (CheckSelfPermission(permission) == (int)Permission.Granted)
            {
                await GetLocationAsync();
                return;
            }

            if (ShouldShowRequestPermissionRationale(permission))
            {
                //Explain to the user why we need to read the contacts
                Toast.MakeText(this, "Location access is required to read current location.", ToastLength.Long).Show();
                RequestPermissions(PermissionsLocation, RequestLocationId);
                return;
            }

            RequestPermissions(PermissionsLocation, RequestLocationId);
        }

        // Once permission access or denied this would be invoked to proceed with the application
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            switch (requestCode)
            {
                case RequestLocationId:
                    {
                        if (grantResults[0] == (int)Permission.Granted)
                        {
                            GetLocationAsync();
                        }
                        else
                        {
                            Toast.MakeText(this, "GPS will not be available for Application due denial of GPS permission!", ToastLength.Long).Show();
                        }
                    }
                    break;
            }
        }

        // Finding the current GPS location
        async Task GetLocationAsync()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 500000;
                var position = await locator.GetPositionAsync(50000);
                Location loc = new Location(_locationProvider);
                loc.Latitude = position.Latitude;
                loc.Longitude = position.Longitude;
                LocationHandler.Instance().CurrentLocation = loc;
ILocationHandler.CurrentLocation = loc;
            }
            catch (Exception ex)
            {

                Toast.MakeText(this, "Unable to get location: " + ex.ToString(), ToastLength.Long).Show();
            }
        }

        public void OnProviderDisabled(string provider) { }

        public void OnProviderEnabled(string provider) { }

        public void OnStatusChanged(string provider, Availability status, Bundle extras) { }
    }
}
