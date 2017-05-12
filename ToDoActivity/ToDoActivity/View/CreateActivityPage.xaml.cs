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

			if (activityModel != null)
			{
				Title = "Edit";
			}

			BindingContext = new CreateActivityViewModel(Navigation, activityModel);
		}
	}
}
