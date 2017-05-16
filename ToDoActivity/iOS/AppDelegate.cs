using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace ToDoActivity.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : FormsApplicationDelegate
	{
		private int recentActivityId;

		public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
		{
			Forms.Init();
			LoadApplication(new App());

			// Check for a local notification
			if (launchOptions != null && launchOptions.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
			{
				var localNotification = launchOptions[UIApplication.LaunchOptionsLocalNotificationKey] as UILocalNotification;
				if (localNotification != null)
				{
					// Handle Notification
					HandleLocalNotification(localNotification);
				}
			}
			return base.FinishedLaunching(uiApplication, launchOptions);
		}

		public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
		{
			// Handle Notification
			HandleLocalNotification(notification);
		}

		// Private Method
		private void HandleLocalNotification(UILocalNotification localNotification)
		{
			var appState = UIApplication.SharedApplication.ApplicationState;

			// Reset our badge
			UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;

			if (localNotification != null)
			{
				var userInfo = localNotification.UserInfo;

				if (userInfo != null)
				{
					NSNumber notificationId = (NSNumber)userInfo["kIdKey"];

					if (recentActivityId != notificationId.Int32Value)
					{
						recentActivityId = notificationId.Int32Value;

						if (appState == UIApplicationState.Active)
						{
							MessagingCenter.Send<object, int>(this, "ShowAlertMessage", recentActivityId);
						}
						else
						{
							MessagingCenter.Send<object, int>(this, "OpenActivityDetailPage", recentActivityId);
						}
					}
				}
			}
		}
	}
}
