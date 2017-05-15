using System;
using UIKit;
using Foundation;

namespace ToDoActivity.iOS
{
	public class LocalNotificationHandler
	{
		private static LocalNotificationHandler _instance = new LocalNotificationHandler();

		static public LocalNotificationHandler SharedInstance()
		{
			return _instance;
		}

		public LocalNotificationHandler()
		{
			var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert, null);
			UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
		}

		public void ScheduleNotification(ActivityModel activityModel)
		{
			if (activityModel != null && activityModel.DueDate != null)
			{
				NSDate fireDate = DateUtility.ConvertDateTimeToNSDate(activityModel.DueDate);

				UILocalNotification notification = new UILocalNotification();
				notification.SoundName = UILocalNotification.DefaultSoundName;
				notification.ApplicationIconBadgeNumber = 0;

				notification.FireDate = fireDate;
				notification.TimeZone = NSTimeZone.DefaultTimeZone;

				notification.AlertTitle = activityModel.Name;
				notification.AlertAction = "View";
				notification.AlertBody = activityModel.Description;

				var notificationId = new NSNumber(activityModel.Id);
				var userInfo = new NSDictionary("kIdKey", notificationId);
				notification.UserInfo = userInfo;
				UIApplication.SharedApplication.ScheduleLocalNotification(notification);
			}
		}

		public void UpdateNotification(ActivityModel activityModel)
		{
			CancelNotification(activityModel);
			ScheduleNotification(activityModel);
		}

		public void CancelNotification(ActivityModel activityModel)
		{
			foreach (UILocalNotification notification in UIApplication.SharedApplication.ScheduledLocalNotifications)
			{
				var userInfo = notification.UserInfo;

				if (userInfo != null)
				{
					NSNumber notificationId = (NSNumber)userInfo["kIdKey"];

					if (notificationId.Int32Value == activityModel.Id) { 
						UIApplication.SharedApplication.CancelLocalNotification(notification);
						break;
					}
				}
			}
		}
	}
}
