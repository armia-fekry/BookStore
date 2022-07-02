using BookStore.Application.IRepositories;
using BookStore.Domain;
using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure.Repositories
{
	public class OrderHistoryRepository:BaseRepository<OrderHistory>,IOrderHistoryRepository
	{
		public OrderHistoryRepository(BookStoreContext context):base(context)
		{

		}
	}
}
