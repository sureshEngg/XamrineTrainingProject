using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace ToDoActivity.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			LoadApplication(new App());

			// Check for a local notification
			if (options != null && options.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
			{
				var localNotification = options[UIApplication.LaunchOptionsLocalNotificationKey] as UILocalNotification;
				if (localNotification != null)
				{
					UIAlertController okayAlertController = UIAlertController.Create(localNotification.AlertAction, localNotification.AlertBody, UIAlertControllerStyle.Alert);
					okayAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

					//viewController.PresentViewController(okayAlertController, true, null);

					// reset our badge
					UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
				}
			}
			return base.FinishedLaunching(app, options);
		}

		public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
		{
			UIAlertController okayAlertController = UIAlertController.Create(notification.AlertAction, notification.AlertBody, UIAlertControllerStyle.Alert);
			okayAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
			//viewController.PresentViewController(okayAlertController, true, null);

			// Reset our badge
			UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
		}
	}
}
