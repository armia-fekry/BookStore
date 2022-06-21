using BookStore.Application.IRepositories;
using BookStore.Domain;
using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure.Repositories
{
	public class BookLanguageRepositoy:BaseRepository<BookLanguage>,IBookLanguageRepository
	{
		public BookLanguageRepositoy(BookStoreContext context):base(context)
		{

		}
	}
}
