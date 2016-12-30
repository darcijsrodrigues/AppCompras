using System;
using System.Collections.Generic;
using System.Linq;
using AppCompras.Models;
using SQLite.Net;
using Xamarin.Forms;

namespace AppCompras
{
	public class RepositoryBase<T> : IRepositoryBase<T> where T : Compra, new()
	{
		private static object _locker = new object();
		protected SQLiteConnection dbConn;

		public RepositoryBase()
		{
			dbConn = DependencyService.Get<IFileHelper>().GetConnection();
			//if (dbConn != null)
				dbConn.CreateTable<T>();
		}

		~RepositoryBase()
		{
			dbConn.Dispose();
			dbConn = null;
		}

		public IEnumerable<T> GetAll()
		{
			try
			{
				lock (_locker)
					return dbConn.Table<T>().ToList();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public T GetById(int id)
		{
			try
			{
				lock (_locker)
					return dbConn.Table<T>().FirstOrDefault(entidade => entidade.ID == id);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void InsertOrUpdate(T Entidade)
		{
			try
			{
				if (Entidade != null)
				{
					lock (_locker)
					{
						dbConn.BeginTransaction();
						if (Entidade.ID != 0)
						{
							dbConn.Update(Entidade, typeof(T));
						}
						else {
							 dbConn.Insert(Entidade, typeof(T));
						}
						dbConn.Commit();
					}
				}
			}
			catch (Exception ex)
			{
				dbConn.Rollback();
				throw ex;
			}
		}

		public void Delete(int id)
		{
			try
			{
				lock (_locker)
				{
					dbConn.BeginTransaction();
					dbConn.Delete<T>(id);
					dbConn.Commit();
				}
			}
			catch (Exception ex)
			{
				dbConn.Rollback();
				throw ex;
			}
		}

		public void DeleteAll()
		{
			try
			{
				lock (_locker)
				{
					dbConn.BeginTransaction();
					dbConn.DeleteAll<T>();
					dbConn.Commit();
				}
			}
			catch (Exception ex)
			{
				dbConn.Rollback();
				throw ex;
			}
		}
	}
}
