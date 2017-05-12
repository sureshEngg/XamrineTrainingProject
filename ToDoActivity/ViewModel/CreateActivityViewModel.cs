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
		public string DueDate { get; set; }
		public string Lattitude { get; set; }
		public string Longitude { get; set; }
		public string Status { get; set; }

		public CreateActivityViewModel(INavigation navigation, ActivityModel activityModel)
		{
			DependencyService.Get<IGeoLocation>().InitializeLocationManager();
			this.navigation = navigation;
			SaveCommand = new Command(Save);

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
			else
			{
				double lattitude = DependencyService.Get<IGeoLocation>().GetDeviceLattitude();
				double longitude = DependencyService.Get<IGeoLocation>().GetDeviceLongitude();
				Lattitude = lattitude.ToString();
				Longitude = longitude.ToString();
			}
		}

		public Command SaveCommand { get; private set; }

		public void Save()
		{
			
			//navigation.PopToRootAsync();
			//this.activityModel

		}
	}
}
