using BookStore.Application.IRepositories;
using BookStore.Application.Services.BooksServices.Dto;
using BookStore.Domain;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
	public class BookRepository : BaseRepository<Book>, IBookRepository
	{
		private readonly BookStoreContext _context;

		public BookRepository(BookStoreContext context):base(context)
		{
			this._context = context;
		}

		public async Task<IEnumerable<BookDto>> GetBooksAsync(int page, int pageSize)
		{

			var res =  await _context.Books.OrderBy(b => b.BookId)
				.Include(e => e.Authors)
				.Include(e=>e.Language)
				.Include(e=>e.Publisher)
				.Skip(page)
				.Take(pageSize)
				.Select(e => new BookDto()
				{
					Path = e.Path,
					Title = e.Title,
					BookLanguage=e.Language.LanguageName,
					Publisher=e.Publisher.PublisherName,
					Authers = string.Join('-', e.Authors.Select(e => e.AuthorName).ToArray())
				})
				.ToListAsync();
			return res;
		}
	}
}
