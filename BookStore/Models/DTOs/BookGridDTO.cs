using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStore.Models.DTOs
{
	public class BookGridDTO:GridDTO
	{
		//[JsonIgnore]
		public const string DefaultFilter = "all";
		public string Author { get; set; } = DefaultFilter;
		public string Genre { get; set; } = DefaultFilter;
		public string Price { get; set; } = DefaultFilter;
	}
}
