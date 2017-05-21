using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using ToDoActivity;

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

		// Constructor Method
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
			}
			else
			{
				SelectedDate = DateTime.Now;

				double lattitude = DependencyService.Get<ILocationHelper>().GetDeviceLattitude();
				double longitude = DependencyService.Get<ILocationHelper>().GetDeviceLongitude();
				Lattitude = lattitude.ToString();
				Longitude = longitude.ToString();
			}
		}

		// Public Methods

		public async void SaveRecentEntries()
		{
			if (activityModel == null && (Name.Length > 0 || Description.Length > 0))
			{
				bool shouldUpdate = true;
				var entryModel = await RecentEntryModel.GetItemAsync();

				if (entryModel == null)
				{
					shouldUpdate = false;
					entryModel = new RecentEntryModel();
				}

				if (Name.Length > 0)
				{
					entryModel.Name = Name;
				}
				else 
				{
					entryModel.Name = string.Empty;
				}

				if (Description.Length > 0)
				{
					entryModel.Description = Description;
				}
				else
				{
					entryModel.Description = string.Empty;
				}
				await entryModel.SaveItemAsync(shouldUpdate);
			}
		}

		// User Actions
		async void Save()
		{
			if (isDateValid && Name.Length > 0 && Description.Length > 0)
			{
				bool shouldUpdate = true;

				if (activityModel == null)
				{
					shouldUpdate = false;
					activityModel = new ActivityModel();
				}
				else
				{
					//Cancel scheduled notification
					DependencyService.Get<ILocalNotificationHelper>().CancelNotification(activityModel);
				}

				activityModel.Name = Name;
				activityModel.DueDate = SelectedDate;
				activityModel.Description = Description;
				activityModel.Lattitude = DependencyService.Get<ILocationHelper>().GetDeviceLattitude();
				activityModel.Longitude = DependencyService.Get<ILocationHelper>().GetDeviceLongitude();

				// Save activity
				await activityModel.SaveItemAsync(shouldUpdate);

				// Schedule notification
				DependencyService.Get<ILocalNotificationHelper>().ScheduleNotification(this.activityModel);

				// Delete recent entry data
				var recentEntryModel = await RecentEntryModel.GetItemAsync();

				if (recentEntryModel != null)
				{
					await recentEntryModel.DeleteItemAsync();
				}

				//Pop to root view page.
				await navigation.PopToRootAsync();
			}
		}

		async void Delete()
		{
			//Cancel scheduled notification
			DependencyService.Get<ILocalNotificationHelper>().CancelNotification(activityModel);

			// Save activity
			await activityModel.DeleteItemAsync();

			//Pop to root view page.
			await navigation.PopToRootAsync();
		}
	}
}
