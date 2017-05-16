using Xamarin.Forms;

namespace ToDoActivity
{

	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			HomePage homePage = new HomePage();
			MainPage = new NavigationPage(homePage);
			DependencyService.Get<IGeoLocation>().InitializeDependencyServices();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
