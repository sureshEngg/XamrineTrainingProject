
using System;

namespace ToDoActivity
{

	public interface IGeoLocation
	{
		void InitializeDependencyServices();
		double GetDeviceLattitude();
		double GetDeviceLongitude();
		void ScheduleNotification(ActivityModel activityModel);
		void UpdateNotification(ActivityModel activityModel);
		void CancelNotification(ActivityModel activityModel);
	}
}
