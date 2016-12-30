using System;
using SQLite.Net;

namespace AppCompras
{
	public interface IFileHelper
	{
		SQLiteConnection GetConnection();
	}
}
