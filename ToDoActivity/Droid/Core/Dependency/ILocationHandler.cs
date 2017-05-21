using Android.Locations;
using ToDoActivity.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ILocationHandler))]
namespace ToDoActivity.Droid
{
	public class ILocationHandler : ILocationHelper
	{
		public static Location CurrentLocation { get; set; }

		public ILocationHandler()
		{
			
		}

		public double GetDeviceLattitude()
		{
			double lattitude = 0.0;

			if (CurrentLocation != null)
			{
				lattitude = CurrentLocation.Latitude;
			}
			return lattitude;
		}

		public double GetDeviceLongitude()
		{
			double longitude = 0.0;

			if (CurrentLocation != null)
			{
				longitude = CurrentLocation.Longitude;
			}
			return longitude;
		}
	}
}
