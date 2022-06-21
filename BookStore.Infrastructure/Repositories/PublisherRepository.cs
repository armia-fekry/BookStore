using BookStore.Application.IRepositories;
using BookStore.Domain;
using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure.Repositories
{
	public class PublisherRepository:BaseRepository<Publisher>,IPublisherRepository
	{
		public PublisherRepository(BookStoreContext context):base(context)
		{

		}
	}
}
