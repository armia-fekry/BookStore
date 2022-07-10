using BookStore.Application.IRepositories;
using BookStore.Domain.Domain;
using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure.Repositories
{
	public class CategoryRepository:BaseRepository<Category>,ICategoryRepository
	{
		public CategoryRepository(BookStoreContext context):base(context)
		{

		}
	}
}
