using BookStore.Application.IRepositories;
using BookStore.Application.Services.BooksServices.Dto;
using BookStore.Application.Shared;
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

		public async Task<IEnumerable<Book>> GetBooksAsync(int page, int pageSize)
		{

			var res =  await _context.Books.OrderBy(b => b.BookId)
				.Include(e => e.Authors)
				.Include(e=>e.Language)
				.Include(e=>e.Publisher)
				.Include(e=>e.Category)
				.Skip(page)
				.Take(pageSize)
				.ToListAsync();
			return res;
		}
	}
}
