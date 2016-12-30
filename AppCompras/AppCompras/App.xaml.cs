using AppCompras.Views;
using SQLite;
using Xamarin.Forms;

namespace AppCompras
{
	public partial class App : Application
	{ 
		static RepositoryCompra dbCompra;

		public App()
		{
			RepositoryCompra dbComprax = new RepositoryCompra();
			dbComprax.DeleteAll();

			InitializeComponent();


			MainPage = new NavigationPage(new ViewListaCompras());
		}

		public static RepositoryCompra DbCompra
		{
			get
			{
				if (dbCompra == null)
				{
					dbCompra = new RepositoryCompra();
				}
				return dbCompra;
			}
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
