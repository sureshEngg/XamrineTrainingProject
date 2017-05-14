using System;
using Xamarin.Forms;
using ToDoActivity.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidDependencyService))]
namespace ToDoActivity.Droid
{
	public class AndroidDependencyService : IGeoLocation
	{

		public void InitializeDependencyServices()
		{
			LocationHandler.Instance();
			NotificationHandler.SharedInstance();
		}

		// Location Dependency
		public double GetDeviceLattitude()
		{
			double lattitude = 0.0;

			if (LocationHandler.Instance().CurrentLocation != null)
			{
				lattitude = LocationHandler.Instance().CurrentLocation.Latitude;
			}
			return lattitude;
		}

		public double GetDeviceLongitude()
		{
			double longitude = 0.0;
			if (LocationHandler.Instance().CurrentLocation != null)
			{
				longitude = LocationHandler.Instance().CurrentLocation.Longitude;
			}
			return longitude;
		}

		// Notification Dependency
		public void ScheduleNotification(ActivityModel activityModel)
		{
			NotificationHandler.SharedInstance().ScheduleNotification(activityModel);
		}

		public void UpdateNotification(ActivityModel activityModel)
		{

		}

		public void CancelNotification(ActivityModel activityModel)
		{

		}
	}
}
