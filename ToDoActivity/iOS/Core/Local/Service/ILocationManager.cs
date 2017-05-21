using System;
using CoreLocation;

namespace ToDoActivity.iOS
{
	public class ILocationManager : CLLocationManagerDelegate
	{
		public CLLocation CurrentLocation { get; set; }

		private static ILocationManager _instance = new ILocationManager();
		private CLLocationManager LocationService { get; set; }

		static public ILocationManager Instance()
		{
			return _instance;
		}

		public ILocationManager()
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
			}
			else
			{
				LocationService.AuthorizationChanged += (sender, args) =>
				{
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
