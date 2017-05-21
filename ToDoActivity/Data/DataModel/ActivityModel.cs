using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;


namespace ToDoActivity
{
	public class ActivityModel : BaseDataModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DueDate { get; set; }
		public bool Completed { get; set; }
		public double Lattitude { get; set; }
		public double Longitude { get; set; }

		// Public Method

		public static Task<List<ActivityModel>> GetItemsAsync()
		{
			return DatabaseManager.SharedInstance().database.Table<ActivityModel>().ToListAsync();
		}

		//public static Task<List<ActivityModel>> GetItemsNotDoneAsync()
		//{
		//	return DatabaseManager.SharedInstance().database.QueryAsync<ActivityModel>("SELECT * FROM [ActivityModel]");
		//}

		//public static Task<ActivityModel> GetItemAsync(int id)
		//{
		//	return DatabaseManager.SharedInstance().database.Table<ActivityModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
		//}
	}
}
