using BookStore.Application.IRepositories;
using BookStore.Domain;
using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure.Repositories
{
	public  class OrderLineRepository:BaseRepository<OrderLine>,IorderLineRepository
	{
		public OrderLineRepository(BookStoreContext context):base(context)
		{

		}
	}
}
