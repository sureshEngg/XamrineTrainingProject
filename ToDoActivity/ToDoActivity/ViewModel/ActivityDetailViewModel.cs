﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDoActivity
{
	public class ActivityDetailViewModel : BaseViewModel
	{
		private ActivityModel activityModel;
		private INavigation navigation;

		public string Name { get; set; }
		public string Description { get; set; }
		public string DueDate { get; set; }
		public string Lattitude { get; set; }
		public string Longitude { get; set; }
		public string Status { get; set; }

		public ActivityDetailViewModel(INavigation navigation, ActivityModel activityModel)
		{
			this.navigation = navigation;

			if (activityModel != null)
			{
				this.activityModel = activityModel;
				Name = activityModel.Name;
				Description = activityModel.Description;
				DueDate = activityModel.Name;
				Lattitude = activityModel.Lattitude.ToString();
				Longitude = activityModel.Longitude.ToString();
				Status = activityModel.Completed.ToString();
			}

			EditCommand = new Command(Edit);
		}

		public Command EditCommand { get; private set; }

		public void Edit()
		{
			navigation.PushAsync(new CreateActivityPage(activityModel));
		}
	}
}
