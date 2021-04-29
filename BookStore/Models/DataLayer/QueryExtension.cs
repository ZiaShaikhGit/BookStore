using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.DataLayer
{
	public static class QueryExtension
	{
		public static IQueryable<T> PageBy<T>(this IQueryable<T> items, int pageNumber, int pageSize)
		{
			return items.Skip((pageNumber - 1) * pageSize).Take(pageSize);
		}
	}
}
