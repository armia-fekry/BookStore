
using BookStore.Domain;
using System.Linq.Expressions;

namespace BookStore.Application.IRepositories
{
	public interface IBookRepository:IBaseRepository<Book>
	{
		Task<IEnumerable<Book>> GetBooksAsync(Expression<Func<Book, bool>> expression,int page=0,int pageSize=100);
	}
}
