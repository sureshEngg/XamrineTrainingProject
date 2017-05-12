//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using SQLite;

//namespace ToDoActivity
//{
//	public class DatabaseManager
//	{
//		readonly SQLiteAsyncConnection database;

//		public DatabaseManager()
//		{
//			database = new SQLiteAsyncConnection(dbPath);
//			database.CreateTableAsync<ActivityModel>().Wait();
//		}

//		public Task<List<ActivityModel>> GetItemsAsync()
//		{
//			return database.Table<ActivityModel>().ToListAsync();
//		}

//		public Task<List<ActivityModel>> GetItemsNotDoneAsync()
//		{
//			return database.QueryAsync<ActivityModel>("SELECT * FROM [ActivityModel]");
//		}

//		public Task<ActivityModel> GetItemAsync(int id)
//		{
//			return database.Table<ActivityModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
//		}

//		public Task<int> SaveItemAsync(ActivityModel item)
//		{
//			if (item.Id != 0)
//			{
//				return database.UpdateAsync(item);
//			}
//			else
//			{
//				return database.InsertAsync(item);
//			}
//		}

//		public Task<int> DeleteItemAsync(ActivityModel item)
//		{
//			return database.DeleteAsync(item);
//		}
//	}
//}

