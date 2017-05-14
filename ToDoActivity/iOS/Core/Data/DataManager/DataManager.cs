using System;
using System.IO;
using SQLite;

namespace ToDoActivity.iOS
{
	public class DataManager
	{
		private static DataManager singletonInstance = new DataManager();

		static public DataManager SharedInstance()
		{
			return singletonInstance;
		}

		//public DataManager()
		//{
		//	var dbPath = GetLocalFilePath("TodoSQLite.db3");
		//	database = new SQLiteAsyncConnection(dbPath);
		//	database.CreateTableAsync<ActivityModel>().Wait();
		//}



		private string GetLocalFilePath(string filename)
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

			if (!Directory.Exists(libFolder))
			{
				Directory.CreateDirectory(libFolder);
			}
			return Path.Combine(libFolder, filename);
		}
	}
}
