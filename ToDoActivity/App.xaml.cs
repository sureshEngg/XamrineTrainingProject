using Xamarin.Forms;

namespace ToDoActivity
{

	public partial class App : Application
	{
		HomePage homePage;

		public App()
		{
			InitializeComponent();
			homePage = new HomePage();
			MainPage = new NavigationPage(homePage);
		}

		protected override void OnStart()
		{
			// Add observer to handle local notification
			SubscribeObserver();
		}

		protected override void OnSleep()
		{
			// Remove local notification observer
			UnsubscribeObserver();
		}

		protected override void OnResume()
		{
			// Add observer to handle local notification
			SubscribeObserver();
		}

		// Private Methods

		private void SubscribeObserver()
		{
			MessagingCenter.Subscribe<object, int>(this, Constant.kOpenActivityDetailPageKey, (sender, activityId) =>
			{
				Device.BeginInvokeOnMainThread(() =>
				{
					// Handle user action on local notification
					homePage.HandleLocalNotification(activityId, false);
				});
			});

			MessagingCenter.Subscribe<object, int>(this, Constant.kShowAlertMessageKey, (sender, activityId) =>
			{
				Device.BeginInvokeOnMainThread(() =>
				{
					// Show alert for activity start.
					homePage.HandleLocalNotification(activityId, true);
				});
			});
		}

		private void UnsubscribeObserver()
		{
			// Remove local notification observer
			MessagingCenter.Unsubscribe<object>(this, Constant.kOpenActivityDetailPageKey);
			MessagingCenter.Unsubscribe<object>(this, Constant.kShowAlertMessageKey);
		}
	}
}
