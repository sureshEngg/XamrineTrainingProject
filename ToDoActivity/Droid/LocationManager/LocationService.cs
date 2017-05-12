
using System;
using Xamarin.Forms;
using Android.Content;
using Android.Runtime;
using Android.Views;
using ToDoActivity.Droid;
using Android.Locations;
using System.Collections.Generic;
using System.Linq;
using Android.Util;
using Android.OS;
using System.Threading.Tasks;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(LocationService))]
namespace ToDoActivity.Droid
{
	public class LocationService : IGeoLocation, ILocationListener
	{
		//private static LocationService _instance = new LocationService();

		//private LocationService()
		//{
		//	InitializeLocationManager();
		//}

		//static public LocationService Instance()
		//{
		//	return _instance;
		//}

		static readonly string TAG = "X:" + typeof(LocationService).Name;

		Location currentLocation;
		LocationManager locationManager;
		string locationProvider;

		public double GetDeviceLattitude()
		{
			double lattitude = 0.0;

			if (currentLocation != null)
			{
				lattitude = currentLocation.Latitude;
			}
			return lattitude;
		}

		public double GetDeviceLongitude()
		{
			double longitude = 0.0;
			if (currentLocation != null)
			{
				longitude = currentLocation.Longitude;
			}
			return longitude;
		}

		public void InitializeLocationManager()
		{
			Toast.MakeText(Forms.Context, "Starting...", ToastLength.Long).Show();
			locationManager = Android.App.Application.Context.GetSystemService(Context.LocationService).JavaCast<LocationManager>();

			Criteria criteriaForLocationService = new Criteria
			{
				Accuracy = Accuracy.Fine
			};

			IList<string> acceptableLocationProviders = locationManager.GetProviders(criteriaForLocationService, true);

			if (acceptableLocationProviders.Any())
			{
				locationProvider = acceptableLocationProviders.First();
			}
			else
			{
				locationProvider = string.Empty;
			}
			Log.Debug(TAG, "Using " + locationProvider + ".");
			Toast.MakeText(Forms.Context, "Ending...", ToastLength.Long).Show();
		}



		public IntPtr Handle
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public void OnProviderDisabled(string provider)
		{
			throw new NotImplementedException();
		}

		public void OnProviderEnabled(string provider)
		{
			throw new NotImplementedException();
		}

		public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public void OnLocationChanged(Location location)
		{
			currentLocation = location;
		}
	}
}
