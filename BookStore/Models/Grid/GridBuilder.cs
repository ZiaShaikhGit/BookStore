using BookStore.Models.DTOs;
using BookStore.Models.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Grid
{
	public class GridBuilder
	{
		public const string RoutKey = "currentroute";
		public RouteDictionary Routes { get; set; }
		public ISession Session { get; set; }

		public GridBuilder(ISession sess)
		{
			Session = sess;
			Routes = Session.GetObject<RouteDictionary>(RoutKey) ?? new RouteDictionary();
		}

		public GridBuilder(ISession sess,GridDTO values,string defaultSortFeild)
		{
			sess = Session;
			Routes = new RouteDictionary();
			Routes.PageNumber = values.PageNumber;
			Routes.PageSize = values.PageSize;
			Routes.SortField = values.SortField;

			SaveRouteSegment();
		}

		public void SaveRouteSegment() =>
			Session.SetObject<RouteDictionary>(RoutKey, Routes);

		public int GetTotalPages(int count)
		{
			int size = Routes.PageSize;
			return (count + size - 1) / size;
		}

		public RouteDictionary CurrentRoute => Routes;
		
	}
}
