using System;
using System.Diagnostics;
using System.Collections.Generic;
using Xamarin.Forms;
using SQLite;

namespace ToDoActivity
{
	public partial class HomePage : ContentPage
	{
		private int lastOpenedToDoId;
		private HomeViewModel homeViewModel;

		public HomePage()
		{
			InitializeComponent();
			homeViewModel = new HomeViewModel();
			BindingContext = homeViewModel;

			ToolbarItems.Add(new ToolbarItem("New", null, () =>
			{
				Navigation.PushAsync(new CreateActivityPage(null));
			}));

			// Update Back button name
			NavigationPage.SetBackButtonTitle(this, "Back");
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			lastOpenedToDoId = 0;
			toDoList.ItemsSource = await ActivityModel.GetItemsAsync();
			SubscribeObserver();
		}

		private void SubscribeObserver()
		{
			MessagingCenter.Subscribe<object, int>(this, "OpenActivityDetailPage", (sender, activityId) =>
			{
				Device.BeginInvokeOnMainThread(() =>
				{
					HandleLocalNotification(activityId, false);
				});

			});

			MessagingCenter.Subscribe<object, int>(this, "ShowAlertMessage", (sender, activityId) =>
			{
				Device.BeginInvokeOnMainThread(() =>
				{
					HandleLocalNotification(activityId, true);
				});
			});
		}


		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			lastOpenedToDoId = 0;

			MessagingCenter.Unsubscribe<object>(this, "OpenActivityDetailPage");
			MessagingCenter.Unsubscribe<object>(this, "ShowAlertMessage");
		}

		private void OnItemSelected(object o, ItemTappedEventArgs e)
		{
			// Deselect cell
			toDoList.SelectedItem = null;

			var activityModel = e.Item as ActivityModel;
			Navigation.PushAsync(new ActivityDetailPage(activityModel));
		}

		private void HandleLocalNotification(int activityId, bool showAlert)
		{
			if (lastOpenedToDoId != activityId)
			{
				lastOpenedToDoId = activityId;

				foreach (ActivityModel model in toDoList.ItemsSource)
				{
					if (model.Id == activityId)
					{
						if (showAlert)
						{
							DisplayAlert(model.Name, model.Description, "OK");
						}
						else
						{
							if (Navigation.NavigationStack.Count > 1)
							{
								Navigation.PopToRootAsync();
							}
							Navigation.PushAsync(new ActivityDetailPage(model));
						}
						break;
					}
				}
			}
		}
	}
}
