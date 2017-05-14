using System;
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
			homeViewModel = new HomeViewModel(Navigation);
			BindingContext = homeViewModel;

			ToolbarItems.Add(new ToolbarItem("New", null, () =>
			{
				Navigation.PushAsync(new CreateActivityPage(null));
			}));

			// Update Back button name
			NavigationPage.SetBackButtonTitle(this, "Back");
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
