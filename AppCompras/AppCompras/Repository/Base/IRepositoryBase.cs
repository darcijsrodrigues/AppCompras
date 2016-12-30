using System;
using System.Collections.Generic;

namespace AppCompras
{
	public interface IRepositoryBase<T>
	{
		IEnumerable<T> GetAll();

		T GetById(int id);

		void InsertOrUpdate(T Entidade);

		void Delete(int id);

		void DeleteAll();
	}
}
