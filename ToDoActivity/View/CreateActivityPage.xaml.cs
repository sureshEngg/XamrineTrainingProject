using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ToDoActivity
{
	public partial class CreateActivityPage : ContentPage
	{
		public CreateActivityPage(ActivityModel activityModel)
		{
			InitializeComponent();
			BindingContext = new CreateActivityViewModel(Navigation, activityModel);

			if (activityModel != null)
			{
				Title = "Edit";
				deleteButton.IsVisible = true;
			}
		}
	}
}
