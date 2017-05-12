
using System;

namespace ToDoActivity
{

	public interface IGeoLocation
	{
		void InitializeLocationManager();
		double GetDeviceLattitude();
		double GetDeviceLongitude();

	}
}
