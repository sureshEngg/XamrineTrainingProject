using System;
using ToDoActivity.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(ILocationDependancy))]
namespace ToDoActivity.iOS
{
	public class ILocationDependancy : ILocationHelper
	{
		public ILocationDependancy()
		{
			ILocationManager.Instance();
		}

		// Location Dependency Methods
		public double GetDeviceLattitude()
		{
			double lattitude = 0.0;

			if (ILocationManager.Instance().CurrentLocation != null)
			{
				lattitude = ILocationManager.Instance().CurrentLocation.Coordinate.Latitude;
			}
			return lattitude;
		}

		public double GetDeviceLongitude()
		{
			double longitude = 0.0;
			if (ILocationManager.Instance().CurrentLocation != null)
			{
				longitude = ILocationManager.Instance().CurrentLocation.Coordinate.Longitude;
			}

			return longitude;
		}
	}
}
