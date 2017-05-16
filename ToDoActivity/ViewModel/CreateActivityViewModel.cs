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
		public DateTime SelectedDate { get; set; }

		public string Lattitude { get; set; }
		public string Longitude { get; set; }
		public string Status { get; set; }
		public bool isDateValid { get; set; }

		public Command SaveCommand { get; private set; }
		public Command DeleteCommand { get; private set; }

		public CreateActivityViewModel(INavigation navigation, ActivityModel activityModel)
		{
			this.navigation = navigation;
			SaveCommand = new Command(Save);
			DeleteCommand = new Command(Delete);

			if (activityModel != null)
			{
				this.activityModel = activityModel;

				Name = activityModel.Name;
				Description = activityModel.Description;
				SelectedDate = activityModel.DueDate;
				Lattitude = activityModel.Lattitude.ToString();
				Longitude = activityModel.Longitude.ToString();

				// Update Status
				UpdateActivityStatus(activityModel.Completed);
			}
			else
			{
				Name = string.Empty;
				Description = string.Empty;
				SelectedDate = DateTime.Now;

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

		async void Save()
		{
			if (isDateValid && Name.Length > 0 && Description.Length > 0)
			{
				if (activityModel == null)
				{
					activityModel = new ActivityModel();
				}
				else
				{
					//Cancel scheduled notification
					DependencyService.Get<IGeoLocation>().CancelNotification(activityModel);
				}

				activityModel.Name = Name;
				activityModel.DueDate = SelectedDate;
				activityModel.Description = Description;
				activityModel.Completed = false;
				activityModel.Lattitude = DependencyService.Get<IGeoLocation>().GetDeviceLattitude();
				activityModel.Longitude = DependencyService.Get<IGeoLocation>().GetDeviceLongitude();

				// Save activity
				await DatabaseManager.SharedInstance().SaveItemAsync(activityModel);

				// Schedule notification
				DependencyService.Get<IGeoLocation>().ScheduleNotification(this.activityModel);

				//Pop to root view page.
				await navigation.PopToRootAsync();
			}
		}

		async void Delete()
		{
			//Cancel scheduled notification
			DependencyService.Get<IGeoLocation>().CancelNotification(activityModel);

			// Save activity
			await DatabaseManager.SharedInstance().DeleteItemAsync(activityModel);

			//Pop to root view page.
			await navigation.PopToRootAsync();
		}
	}
}
