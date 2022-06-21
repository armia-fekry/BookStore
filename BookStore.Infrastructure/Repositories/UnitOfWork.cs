using BookStore.Application.IRepositories;
using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly BookStoreContext _context;
		public IBookRepository bookRepository { get; private set; }

		public IBookLanguageRepository bookLanguageRepository { get; private set; }

		public IPublisherRepository publisherRepository { get; private set; }

		public UnitOfWork(BookStoreContext context)
		{
			this._context = context;

			bookRepository = new BookRepository(context);
			publisherRepository = new PublisherRepository(context);
			bookLanguageRepository = new BookLanguageRepositoy(context);
		}

		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
