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

			// Register for local notification alerts
			var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert, null);
			UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);

			// Check if app opend through user action on local notification
			if (launchOptions != null && launchOptions.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
			{
				var localNotification = launchOptions[UIApplication.LaunchOptionsLocalNotificationKey] as UILocalNotification;
				if (localNotification != null)
				{
					// Handle action on local lotification
					HandleLocalNotification(localNotification);
				}
			}

			// Create location manager to start location fetch;
			ILocationManager.Instance();

			return base.FinishedLaunching(uiApplication, launchOptions);
		}

		public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
		{
			// Handle action on local lotification
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
					NSNumber notificationId = (NSNumber)userInfo[Constant.kToDoActivityKey];

					if (recentActivityId != notificationId.Int32Value)
					{
						recentActivityId = notificationId.Int32Value;

						if (appState == UIApplicationState.Active)
						{
							MessagingCenter.Send<object, int>(this, Constant.kShowAlertMessageKey, recentActivityId);
						}
						else
						{
							MessagingCenter.Send<object, int>(this, Constant.kOpenActivityDetailPageKey, recentActivityId);
						}
					}
				}
			}
		}
	}
}
