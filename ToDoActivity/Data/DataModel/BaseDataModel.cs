using System;
using System.Threading.Tasks;
using SQLite;

namespace ToDoActivity
{
	public class BaseDataModel
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		public Task<int> SaveItemAsync(bool shouldUpdate)
		{
			if (shouldUpdate)
			{
				return DatabaseManager.SharedInstance().database.UpdateAsync(this);
			}
			else
			{
				return DatabaseManager.SharedInstance().database.InsertAsync(this);
			}
		}

		public Task<int> DeleteItemAsync()
		{
			return DatabaseManager.SharedInstance().database.DeleteAsync(this);
		}
	}
}
