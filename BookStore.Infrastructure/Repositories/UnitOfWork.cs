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
		public ICustOrderRepository custOrderRepository { get; private set; }
		public IShippingMethodRepository shippingMethodRepository { get; private set; }
		public ICustomerAdressesRepository customerAdressesRepository { get; private set; }
		public ICustomerRepository customerRepository { get; private set; }
		public IOrderHistoryRepository orderHistoryRepository { get; private set; }

		public IorderLineRepository orderLineRepository { get; private set; }

		public UnitOfWork(BookStoreContext context)
		{
			this._context = context;

			bookRepository = new BookRepository(context);
			publisherRepository = new PublisherRepository(context);
			bookLanguageRepository = new BookLanguageRepositoy(context);
			custOrderRepository=new CustOrderRepository(context);
			customerRepository=new CustomerRepository(context);
			customerAdressesRepository=new CustomerAdressesRepository(context);
			shippingMethodRepository=new ShippingMethodRepository(context);
			orderLineRepository=new OrderLineRepository(context);
			orderHistoryRepository=new OrderHistoryRepository(context);
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
