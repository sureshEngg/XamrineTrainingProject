using System;
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

		public ActivityDetailViewModel(INavigation navigation, ActivityModel activityModel)
		{
			this.navigation = navigation;

			if (activityModel != null)
			{
				this.activityModel = activityModel;
				Name = activityModel.Name;
				Description = activityModel.Description;
				DueDate = activityModel.DueDate.ToString();
				Lattitude = activityModel.Lattitude.ToString();
				Longitude = activityModel.Longitude.ToString();
			}

			EditCommand = new Command(Edit);
			DeleteCommand = new Command(Delete);
		}

		public Command EditCommand { get; private set; }
		public Command DeleteCommand { get; private set; }

		async void Edit()
		{
			await navigation.PushAsync(new CreateActivityPage(activityModel));
		}

		async void Delete()
		{
			//Cancel scheduled notification
			DependencyService.Get<ILocalNotificationHelper>().CancelNotification(activityModel);

			// Save activity
			await activityModel.DeleteItemAsync();

			// Pop to home page.
			await navigation.PopAsync();
		}
	}
}
