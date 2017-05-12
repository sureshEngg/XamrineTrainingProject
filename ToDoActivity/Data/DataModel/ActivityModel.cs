using System;

namespace ToDoActivity
{
	public class ActivityModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DueDate { get; set; }
		public bool Completed { get; set; }
		public float Lattitude { get; set; }
		public float Longitude { get; set; }
	}
}
