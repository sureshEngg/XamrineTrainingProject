
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

[assembly: Xamarin.Forms.Dependency(typeof(LocationHandler))]
namespace ToDoActivity.Droid
{
	public class LocationHandler
	{
		private static LocationHandler _instance = new LocationHandler();

		static readonly string TAG = "X:" + typeof(LocationHandler).Name;

		public Location CurrentLocation { get; set;}
		LocationManager locationManager;
		string locationProvider;

		private LocationHandler()
		{
			//InitializeLocationService();
		}

		static public LocationHandler Instance()
		{
			return _instance;
		}
	}
}
