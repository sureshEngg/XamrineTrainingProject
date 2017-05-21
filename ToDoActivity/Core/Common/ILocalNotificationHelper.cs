using System;

namespace ToDoActivity
{
	public interface ILocalNotificationHelper
	{
		void ScheduleNotification(ActivityModel activityModel);
		void UpdateNotification(ActivityModel activityModel);
		void CancelNotification(ActivityModel activityModel);
	}
}
