using BookStore.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.DataLayer.SeedData
{
	public class SeedGeneres : IEntityTypeConfiguration<Genre>
	{
		public void Configure(EntityTypeBuilder<Genre> builder)
		{
			builder.HasData(
				new Genre { GenreId="novel",Name="Novel"},
				new Genre { GenreId = "memoir", Name = "Memoir" },
				new Genre { GenreId = "mystery", Name = "Mystery" },
				new Genre { GenreId = "scifi", Name = "Scifi" },
				new Genre { GenreId = "history", Name = "History" }
				);
		}
	}
}
