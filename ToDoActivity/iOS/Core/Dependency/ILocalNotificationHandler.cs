using System;
using Xamarin.Forms;
using ToDoActivity.iOS;
using UIKit;
using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(ILocalNotificationHandler))]
namespace ToDoActivity.iOS
{
	public class ILocalNotificationHandler : ILocalNotificationHelper
	{

		public ILocalNotificationHandler()
		{
			
		}

		public void ScheduleNotification(ActivityModel activityModel)
		{
			if (activityModel != null && activityModel.DueDate != null)
			{
				NSDate fireDate = IDateUtility.ConvertDateTimeToNSDate(activityModel.DueDate);

				UILocalNotification notification = new UILocalNotification();
				notification.SoundName = UILocalNotification.DefaultSoundName;
				notification.ApplicationIconBadgeNumber = 0;

				notification.FireDate = fireDate;
				notification.TimeZone = NSTimeZone.DefaultTimeZone;

				notification.AlertTitle = activityModel.Name;
				notification.AlertAction = Constant.kViewTextKey;
				notification.AlertBody = activityModel.Description;

				var notificationId = new NSNumber(activityModel.Id);
				var userInfo = new NSDictionary(Constant.kToDoActivityKey, notificationId);
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
					NSNumber notificationId = (NSNumber)userInfo[Constant.kToDoActivityKey];

					if (notificationId.Int32Value == activityModel.Id)
					{
						UIApplication.SharedApplication.CancelLocalNotification(notification);
						break;
					}
				}
			}
		}
	}
}
