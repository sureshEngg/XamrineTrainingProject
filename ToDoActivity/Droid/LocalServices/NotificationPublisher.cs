﻿using System;
using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Xamarin.Forms;

namespace ToDoActivity.Droid
{

    [BroadcastReceiver]
    public class NotificationPublisher : BroadcastReceiver
    {

        public override void OnReceive(Context context, Intent intent)
        {
            var message = intent.GetStringExtra("message");
            var title = intent.GetStringExtra("title");

            var notIntent = new Intent(context, typeof(MainActivity));
            var contentIntent = PendingIntent.GetActivity(context, 0, notIntent, PendingIntentFlags.CancelCurrent);
            var manager = NotificationManagerCompat.From(context);

            var style = new NotificationCompat.BigTextStyle();
            style.BigText(message);

            //Generate a notification with just short text and small icon
            var builder = new NotificationCompat.Builder(context)
                .SetContentIntent(contentIntent)
                .SetSmallIcon(Resource.Drawable.message)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetStyle(style)
                .SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
                .SetAutoCancel(true);

            var notification = builder.Build();
            manager.Notify(0, notification);
        }
    }
}
