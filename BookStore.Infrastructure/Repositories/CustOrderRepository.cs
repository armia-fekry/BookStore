using BookStore.Application.IRepositories;
using BookStore.Domain;
using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure.Repositories
{
	public class CustOrderRepository:BaseRepository<CustOrder>,ICustOrderRepository
	{

		public CustOrderRepository(BookStoreContext context) : base(context)
		{
		}
	}
}
