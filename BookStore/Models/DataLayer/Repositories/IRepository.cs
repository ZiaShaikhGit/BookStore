using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.DataLayer.Repositories
{
	public interface IRepository<T> where T:class
	{
		IEnumerable<T> List(QueryOptions<T> optons);
		int Count { get; }

		//Overload Get Method
		T Get(QueryOptions<T> options);
		T Get(int id);
		T Get(string id);

		void Insert(T entity);
		void Update(T entity);
		void Delete(T entity);

		void Save();

	}
}
