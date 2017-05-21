using System;
namespace ToDoActivity
{
	public interface ILocationHelper
	{ 
		double GetDeviceLattitude();
		double GetDeviceLongitude();
	}
}
