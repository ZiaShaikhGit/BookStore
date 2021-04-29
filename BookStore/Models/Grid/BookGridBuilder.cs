using BookStore.Models.DomainModels;
using BookStore.Models.DTOs;
using BookStore.Models.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Grid
{
	//inherits the general purpose GridBuilder class and adds application-specific
	//method for loading and clearing filter route segments in route dictionary.
	//Also adds application-specific Boolean flags for sorting and filtering.
	public class BookGridBuilder:GridBuilder
	{
		//this constructor gets current route data from session
		public BookGridBuilder(ISession sess):base(sess)
		{

		}

		//this constructor store filter route segments, as well as 
		//the paging and sorting route segemnts stored by the base constructor
		public BookGridBuilder(ISession sess,BookGridDTO values,string defaultSortFilter):base(sess,values,defaultSortFilter)
		{
			//store filter route segments-add filter prefixes if this is initial load
			//of page with default values rather than route values(route values have prefix)

			bool isInitial = values.Genre.IndexOf(FilterPrefix.Genre) == -1;
			Routes.AuthorFilter = (isInitial) ? FilterPrefix.Author + values.Author : values.Author;
			Routes.GenreFilter= (isInitial) ? FilterPrefix.Genre + values.Genre : values.Genre;
			Routes.PriceFilter = (isInitial) ? FilterPrefix.Price + values.Price : values.Price;

			SaveRouteSegment();
		}

		public void LoadFilterSegments(string[] filter,Author author)
		{
			if (author == null)
				Routes.AuthorFilter = FilterPrefix.Author + filter[0];
			else
				Routes.AuthorFilter = FilterPrefix.Author + filter[0] + "-" + author.FullName.Slug();

			Routes.GenreFilter = FilterPrefix.Genre + filter[1];
			Routes.PriceFilter = FilterPrefix.Genre + filter[2];
		}

		public void ClearFilterSegments() => Routes.ClearFilter();

		//filter flags
		string def = BookGridDTO.DefaultFilter;
		public bool IsFilterByAuthor => Routes.AuthorFilter != def;
		public bool IsFilterByGenre => Routes.GenreFilter != def;
		public bool IsFilterByPrice => Routes.PriceFilter != def;

		//sort flags
		public bool IsSortByGenre => Routes.SortField.EqualsNoCase(nameof(Genre));
		public bool IsSortByPrice => Routes.SortField.EqualsNoCase(nameof(Book.Price));

	}
}
