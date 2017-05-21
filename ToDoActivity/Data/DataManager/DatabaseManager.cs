using System;
using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoActivity
{
	public class DatabaseManager
	{
		private static DatabaseManager sharedInstance = new DatabaseManager();
		public readonly SQLiteAsyncConnection database;

		static public DatabaseManager SharedInstance()
		{
			return sharedInstance;
		}

		public DatabaseManager()
		{
			string dbPath = DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3");
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<ActivityModel>().Wait();
			database.CreateTableAsync<RecentEntryModel>().Wait();
		}
	}
}

