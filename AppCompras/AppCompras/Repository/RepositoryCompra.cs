using System;
using AppCompras.Models;
using SQLite.Net;
using Xamarin.Forms;

namespace AppCompras
{
	public class RepositoryCompra: RepositoryBase<Compra>
	{
		static object locker = new object();
		SQLiteConnection database;

		public RepositoryCompra()
		{
			database = DependencyService.Get<IFileHelper>().GetConnection();
			database.CreateTable<Compra>();
		}
	}
}
