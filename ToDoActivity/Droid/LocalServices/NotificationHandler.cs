using System;
namespace ToDoActivity.Droid
{
	public class NotificationHandler
	{

		private static NotificationHandler _instance = new NotificationHandler();

		static public NotificationHandler SharedInstance()
		{
			return _instance;
		}

		public NotificationHandler()
		{
		}

		public void ScheduleNotification(ActivityModel activityModel)
		{
		}
	}
}
