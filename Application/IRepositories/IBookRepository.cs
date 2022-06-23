
using BookStore.Domain;

namespace BookStore.Application.IRepositories
{
	public interface IBookRepository:IBaseRepository<Book>
	{
		Task<IEnumerable<Book>> GetBooksAsync(int page=0,int pageSize=100);
	}
}
