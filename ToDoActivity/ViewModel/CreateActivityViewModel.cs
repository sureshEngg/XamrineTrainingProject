using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDoActivity
{
	public class CreateActivityViewModel : BaseViewModel
	{
		private ActivityModel activityModel;
		private INavigation navigation;

		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DueDate { get; set; }
		public DateTime DueTime { get; set; }
		public string Lattitude { get; set; }
		public string Longitude { get; set; }
		public string Status { get; set; }

		public CreateActivityViewModel(INavigation navigation, ActivityModel activityModel)
		{
			this.navigation = navigation;
			SaveCommand = new Command(Save);

			if (activityModel != null)
			{
				this.activityModel = activityModel;

				DueDate = activityModel.DueDate;
				DueTime = activityModel.DueDate;

				Name = activityModel.Name;
				Description = activityModel.Description;
				DueDate = activityModel.DueDate;
				Lattitude = activityModel.Lattitude.ToString();
				Longitude = activityModel.Longitude.ToString();

				// Update Status
				UpdateActivityStatus(activityModel.Completed);
			}
			else
			{
				Name = string.Empty;
				Description = string.Empty;
				DueDate = DateTime.Now;
				DueTime = DateTime.Now;

				double lattitude = DependencyService.Get<IGeoLocation>().GetDeviceLattitude();
				double longitude = DependencyService.Get<IGeoLocation>().GetDeviceLongitude();
				Lattitude = lattitude.ToString();
				Longitude = longitude.ToString();

				// Update Status
				UpdateActivityStatus(false);
			}
		}

		private void UpdateActivityStatus(bool isCompleted)
		{
			if (isCompleted)
			{
				Status = "Completed";
			}
			else
			{
				Status = "Not Completed";
			}
		}

		public Command SaveCommand { get; private set; }

		public void Save()
		{
			if (Name.Length > 0 && Description.Length > 0)
			{
				if (activityModel == null)
				{
					activityModel = new ActivityModel();
				}
				else
				{
					DependencyService.Get<IGeoLocation>().CancelNotification(this.activityModel);
				}
				activityModel.Name = Name;
				activityModel.DueDate = new DateTime(DueDate.Year, DueDate.Month, DueDate.Day, DueTime.Hour, DueTime.Minute, 0);
				activityModel.Description = Description;
				activityModel.Completed = false;
				activityModel.Lattitude = DependencyService.Get<IGeoLocation>().GetDeviceLattitude();
				activityModel.Longitude = DependencyService.Get<IGeoLocation>().GetDeviceLongitude();

				DependencyService.Get<IGeoLocation>().ScheduleNotification(this.activityModel);
				navigation.PopToRootAsync();
				//this.activityModel
			}
		}
	}
}
