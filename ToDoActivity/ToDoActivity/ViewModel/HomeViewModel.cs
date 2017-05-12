using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDoActivity
{
	public class HomeViewModel : BaseViewModel
	{
		private INavigation Navigation { get; set; }

		public List<ActivityModel> Activities
		{
			get
			{
				return new List<ActivityModel>()
				{
					new ActivityModel(){ Id = 1, Name = "Test1", Description = "Detail1", DueDate = new DateTime(), Completed = false, Lattitude = 0, Longitude = 0},
					new ActivityModel() { Id = 1, Name = "Test2", Description = "Detail2", DueDate = new DateTime(), Completed = false, Lattitude = 0, Longitude = 0}
				};
			}
		}

		public HomeViewModel(INavigation Navigation)
		{
			this.Navigation = Navigation;
		}
	}
}



//public List<ActivityModel> ActivityList
//{
//	get
//	{
//		if (activityList == null)
//		{
//			activityList = new List<ActivityModel>();
//		}
//		return activityList;
//	}
//	set
//	{
//		activityList = value;
//	}
//}