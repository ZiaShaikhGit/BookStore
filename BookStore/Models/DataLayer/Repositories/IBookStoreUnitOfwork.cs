using BookStore.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.DataLayer.Repositories
{
	public interface IBookStoreUnitOfwork
	{
		Repository<Book> Books { get; }
		Repository<Author> Authors { get; }
		Repository<BookAuthor> BookAuthors { get; }
		Repository<Genre> Genres { get; }

		void DeleteCurrentBookAuthors(Book Books);
		void AddNewBookAuthors(Book book, int[] authorids);
		void Save();
	}
}
