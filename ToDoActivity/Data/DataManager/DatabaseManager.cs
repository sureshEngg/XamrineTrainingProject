using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace ToDoActivity
{
	public class DatabaseManager
	{
		private static DatabaseManager sharedInstance = new DatabaseManager();
		readonly SQLiteAsyncConnection database;

		static public DatabaseManager SharedInstance()
		{
			return sharedInstance;
		}

		public DatabaseManager()
		{
			string dbPath = DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3");
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<ActivityModel>().Wait();
		}

		// Public Method
		public Task<List<ActivityModel>> GetItemsAsync()
		{
			return database.Table<ActivityModel>().ToListAsync();
		}

		public Task<List<ActivityModel>> GetItemsNotDoneAsync()
		{
			return database.QueryAsync<ActivityModel>("SELECT * FROM [ActivityModel]");
		}

		public Task<ActivityModel> GetItemAsync(int id)
		{
			return database.Table<ActivityModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(ActivityModel item)
		{
			if (item.Id != 0)
			{
				return database.UpdateAsync(item);
			}
			else
			{
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(ActivityModel item)
		{
			return database.DeleteAsync(item);
		}
	}
}

