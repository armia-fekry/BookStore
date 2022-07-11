﻿namespace BookStore.Application.IRepositories
{
	public interface IUnitOfWork:IDisposable
	{
		public IBookRepository bookRepository { get; }
		public IPublisherRepository publisherRepository { get; }
		public ICustomerRepository customerRepository { get; }
		public IOrderHistoryRepository orderHistoryRepository { get; }
		public ICustomerAdressesRepository customerAdressesRepository { get; }
		public ICustOrderRepository custOrderRepository { get; }
		public IShippingMethodRepository shippingMethodRepository { get; }
		public IorderLineRepository orderLineRepository { get; }
		public ICategoryRepository categoryRepository { get; }
		int Complete();
	}
}
