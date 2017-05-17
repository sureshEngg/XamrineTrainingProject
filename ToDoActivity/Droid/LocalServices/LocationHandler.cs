using Android.Locations;

namespace ToDoActivity.Droid
{
	public class LocationHandler
	{
		private static LocationHandler _instance = new LocationHandler();

		public Location CurrentLocation { get; set;}

		static public LocationHandler Instance()
		{
			return _instance;
		}
	}
}
