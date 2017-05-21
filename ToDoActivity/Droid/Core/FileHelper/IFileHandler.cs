using System;
using System.IO;
using Xamarin.Forms;
using ToDoActivity.Droid;

[assembly: Dependency(typeof(IFileHandler))]
namespace ToDoActivity.Droid
{
	public class IFileHandler : IFileHelper
	{
		public string GetLocalFilePath(string filename)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return Path.Combine(path, filename);
		}
	}
}
