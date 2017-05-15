using System;
using Android.App;
using Android.Content;
using Xamarin.Forms;

namespace ToDoActivity.Droid
{
	public class NotificationHandler
	{

		private static NotificationHandler _instance = new NotificationHandler();

		static public NotificationHandler SharedInstance()
		{
			return _instance;
		}

		public void ScheduleNotification(ActivityModel activityModel)
		{
			if (activityModel != null)
			{
				Intent alarmIntent = new Intent(Forms.Context, typeof(NotificationPublisher));
				alarmIntent.PutExtra("title", activityModel.Name);
				alarmIntent.PutExtra("message", activityModel.Description);

				PendingIntent pendingIntent = PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
				AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);

				// Set fire date
				alarmManager.Set(AlarmType.RtcWakeup, activityModel.DueDate.Millisecond, pendingIntent);
			}
		}

		public void UpdateNotification(ActivityModel activityModel)
		{
			CancelNotification(activityModel);
			ScheduleNotification(activityModel);
		}

		public void CancelNotification(ActivityModel activityModel)
		{
			//Intent intent = new Intent(Forms.Context, typeof(NotificationPublisher));
			//PendingIntent sender = PendingIntent.GetBroadcast(Forms.Context, 0, intent, 0);

			//AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);
			//alarmManager.Cancel(sender);
		}
	}
}
