using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ToDoActivity
{
	public partial class ActivityDetailPage : ContentPage
	{
		private ActivityDetailViewModel activityDetailViewModel;

		public ActivityDetailPage(ActivityModel activityModel)
		{
			InitializeComponent();
			this.Title = activityModel.Name;

			activityDetailViewModel = new ActivityDetailViewModel(Navigation, activityModel);
			BindingContext = activityDetailViewModel;

			// Update Back button name
			NavigationPage.SetBackButtonTitle(this, Constant.kBackTextKey);
		}
	}
}
