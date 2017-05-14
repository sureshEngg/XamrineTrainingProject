using System;
using SQLite;

namespace ToDoActivity
{
	public class ActivityModel
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DueDate { get; set; }
		public bool Completed { get; set; }
		public double Lattitude { get; set; }
		public double Longitude { get; set; }
	}
}
