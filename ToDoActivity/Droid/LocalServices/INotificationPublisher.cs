using System;
using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Xamarin.Forms;
using Android.OS;
using Android.Media;

namespace ToDoActivity.Droid
{

    [BroadcastReceiver]
    public class INotificationPublisher : BroadcastReceiver
    {

        public override void OnReceive(Context context, Intent intent)
        {
			var message = intent.GetStringExtra(Constant.kMessageTextKey);
			var title = intent.GetStringExtra(Constant.kTitleTextKey);
          
            // When the user clicks the notification, SecondActivity will start up.
            Intent resultIntent = new Intent(context, typeof(MainActivity));

            // Construct a back stack for cross-task navigation:
            Android.Support.V4.App.TaskStackBuilder stackBuilder = Android.Support.V4.App.TaskStackBuilder.Create(context);
            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(MainActivity)));
            stackBuilder.AddNextIntent(resultIntent);

            // Create the PendingIntent with the back stack:            
            PendingIntent resultPendingIntent =
                stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);

            // Build the notification:
            NotificationCompat.Builder builder = new NotificationCompat.Builder(context)
                .SetAutoCancel(true)
                .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification))
                .SetContentTitle(title)
                .SetContentText(message)
                .SetContentIntent(resultPendingIntent)  // Start 2nd activity when the intent is clicked.
                .SetSmallIcon(Resource.Drawable.ic_stat_access_time)  // Display this icon
               ; // The message to display.

            // Finally, publish the notification:
            NotificationManager notificationManager =
                (NotificationManager)context.GetSystemService(Context.NotificationService);
            builder.SetAutoCancel(true);
            notificationManager.Notify(123, builder.Build());
        }
    }
}
