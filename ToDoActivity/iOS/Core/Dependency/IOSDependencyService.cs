using System;
using Xamarin.Forms;
using ToDoActivity.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(IOSDependencyService))]
namespace ToDoActivity.iOS
{
	public class IOSDependencyService : IGeoLocation
	{

		public void InitializeDependencyServices()
		{
			LocationManager.Instance();
			LocalNotificationHandler.SharedInstance();
		}

		// Location Dependency Methods
		public double GetDeviceLattitude()
		{
			double lattitude = 0.0;

			if (LocationManager.Instance().CurrentLocation != null)
			{
				lattitude = LocationManager.Instance().CurrentLocation.Coordinate.Latitude;
			}
			return lattitude;
		}

		public double GetDeviceLongitude()
		{
			double longitude = 0.0;
			if (LocationManager.Instance().CurrentLocation != null)
			{
				longitude = LocationManager.Instance().CurrentLocation.Coordinate.Latitude;
			}
			return longitude;
		}

		// Notification Dependency Methods
		public void ScheduleNotification(ActivityModel activityModel)
		{
			LocalNotificationHandler.SharedInstance().ScheduleNotification(activityModel);
		}

		public void UpdateNotification(ActivityModel activityModel)
		{
			LocalNotificationHandler.SharedInstance().UpdateNotification(activityModel);
		}

		public void CancelNotification(ActivityModel activityModel)
		{
			LocalNotificationHandler.SharedInstance().CancelNotification(activityModel);
		}
	}
}
