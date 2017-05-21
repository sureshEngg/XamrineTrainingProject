using System;
using Android.App;
using Android.Content;
using Xamarin.Forms;
using ToDoActivity.Droid;


[assembly: Xamarin.Forms.Dependency(typeof(INotificationHandler))]
namespace ToDoActivity.Droid
{
    public class INotificationHandler
    {

        private static NotificationHandler _instance = new NotificationHandler();

        static public NotificationHandler SharedInstance()
        {
            return _instance;
        }

        // Schedule the notification for the future time when a TODO due date appears
        public void ScheduleNotification(ActivityModel activityModel)
        {
            if (activityModel != null)
            {
                Intent alarmIntent = new Intent(Forms.Context, typeof(NotificationPublisher));
                alarmIntent.PutExtra("title", activityModel.Name);
                alarmIntent.PutExtra("message", activityModel.Description);

                PendingIntent pendingIntent = PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
                AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);

                double FireTime = activityModel.DueDate.ToUniversalTime().Subtract(
                    new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                        ).TotalMilliseconds;

                // Set fire date
                alarmManager.Set(AlarmType.RtcWakeup, (long)FireTime, pendingIntent);
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
