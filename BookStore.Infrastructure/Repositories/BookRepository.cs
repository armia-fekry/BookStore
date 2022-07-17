using BookStore.Application.IRepositories;
using BookStore.Domain;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.Infrastructure.Repositories
{
	public class BookRepository : BaseRepository<Book>, IBookRepository
	{
		private readonly BookStoreContext _context;

		public BookRepository(BookStoreContext context):base(context)
		{
			this._context = context;
		}

		public async Task<IEnumerable<Book>> GetBooksAsync(Expression<Func<Book, bool>> expression,int page, int pageSize)
		{

			var res =  await _context.Books.OrderBy(b => b.BookId)
				.Where(expression)
				.Include(e => e.Authors)
				.Include(e=>e.Publisher)
				.Include(e=>e.Category)
				.Skip(page)
				.Take(pageSize)
				.ToListAsync();
			return res;
		}
	}
}
