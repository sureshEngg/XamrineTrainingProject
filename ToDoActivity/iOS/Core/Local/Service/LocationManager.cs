using System;
using CoreLocation;

namespace ToDoActivity.iOS
{
	public class LocationManager : CLLocationManagerDelegate
	{
		public CLLocation CurrentLocation { get; set; }

		private static LocationManager _instance = new LocationManager();
		private CLLocationManager LocationService { get; set; }

		static public LocationManager Instance()
		{
			return _instance;
		}

		public LocationManager()
		{
			InitializeLocationService();
		}

		public void InitializeLocationService()
		{
			LocationService = new CLLocationManager();
			LocationService.RequestWhenInUseAuthorization();
			LocationService.Delegate = this;

			if (CLLocationManager.LocationServicesEnabled)
			{
				LocationService.StartUpdatingLocation();
				//LocationService.StartMonitoringSignificantLocationChanges();
			}
			else
			{
				Console.WriteLine("Location services not enabled, please enable this in your Settings");

				LocationService.AuthorizationChanged += (sender, args) =>
				{
					Console.WriteLine("Authorization changed to: {0}", args.Status);
					LocationService.StartUpdatingLocation();
				};
			}
		}

		public override void LocationsUpdated(CLLocationManager manager, CLLocation[] locations)
		{
			if (CLLocationManager.LocationServicesEnabled)
			{
				foreach (var loc in locations)
				{
					CurrentLocation = loc;
				}
			}
		}

	}
}
