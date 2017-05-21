using System;
using System.Threading.Tasks;
using SQLite;

namespace ToDoActivity
{
	public class RecentEntryModel : BaseDataModel
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public RecentEntryModel()
		{
			Name = string.Empty;
			Description = string.Empty;
		}

		// Public Method
		public static Task<RecentEntryModel> GetItemAsync(int id)
		{
			return DatabaseManager.SharedInstance().database.Table<RecentEntryModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
		}
	}
}
