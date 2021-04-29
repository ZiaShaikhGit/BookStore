using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStore.Models.DataLayer
{
	public class QueryOptions<T>
	{
		public Expression<Func<T,Object>> OrderBy { get; set; }
		public string OrderByDirection { get; set; } = "asc";
		public int PageNumber { get; set; }
		public int PageSize { get; set; }

		private string[] include;
		public string Include
		{
			set => include = value.Replace(" ", "").Split(",");
		}

		public string[] GetInclude() => include ?? new string[0];

		public WhereClause<T> WhereClauses { get; set; }
		public Expression<Func<T,bool>> Where
		{
			set
			{
				if (WhereClauses == null)
					WhereClauses = new WhereClause<T>();

				WhereClauses.Add(value);
			}
		}

		public bool HasWhere => WhereClauses != null;
		public bool HasOrderBy => OrderBy != null;
		public bool HasPaging => PageNumber > 0 && PageSize > 0;
	}

	public class WhereClause<T> : List<Expression<Func<T, bool>>> { }
}
