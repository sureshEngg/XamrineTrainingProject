using System;
using System.IO;
using SQLite;
using ToDoActivity.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(IFileHandler))]
namespace ToDoActivity.iOS
{
	public class IFileHandler : IFileHelper
	{
		public string GetLocalFilePath(string filename)
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
