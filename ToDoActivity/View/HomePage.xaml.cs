using System;
using System.Diagnostics;
using System.Collections.Generic;
using Xamarin.Forms;

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
			var source = await DatabaseManager.SharedInstance().GetItemsAsync();

			if (source.Count > 0)
			{
				activityList.ItemsSource = (List<ActivityModel>)source;
			}
			else {
				activityList.ItemsSource = new List<ActivityModel>();
			}
		}

		private void OnItemSelected(object o, ItemTappedEventArgs e)
		{
			// Deselect cell
			activityList.SelectedItem = null;

			var activityModel = e.Item as ActivityModel;
			Navigation.PushAsync(new ActivityDetailPage(activityModel));
		}
	}
}
