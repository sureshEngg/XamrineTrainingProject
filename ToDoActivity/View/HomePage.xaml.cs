using System;
using System.Diagnostics;
using System.Collections.Generic;
using Xamarin.Forms;
using SQLite;

namespace ToDoActivity
{
	public partial class HomePage : ContentPage
	{
		private HomeViewModel homeViewModel;

		public HomePage()
		{
			InitializeComponent();
			homeViewModel = new HomeViewModel();
			BindingContext = homeViewModel;

			ToolbarItems.Add(new ToolbarItem(Constant.kNewTextKey, null, () =>
			{
				Navigation.PushAsync(new CreateActivityPage(null));
			}));

			// Update Back button name
			NavigationPage.SetBackButtonTitle(this, Constant.kBackTextKey);
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			toDoList.ItemsSource = await ActivityModel.GetItemsAsync();
		}

		private void OnItemSelected(object o, ItemTappedEventArgs e)
		{
			// Deselect cell
			toDoList.SelectedItem = null;

			var activityModel = e.Item as ActivityModel;
			Navigation.PushAsync(new ActivityDetailPage(activityModel));
		}

		public void HandleLocalNotification(int activityId, bool showAlert)
		{
			foreach (ActivityModel model in toDoList.ItemsSource)
			{
				if (model.Id == activityId)
				{
					if (showAlert)
					{
						DisplayAlert(model.Name, model.Description, Constant.kOkTextKey);
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
