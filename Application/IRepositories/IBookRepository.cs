
using BookStore.Application.Services.BooksServices.Dto;
using BookStore.Domain;

namespace BookStore.Application.IRepositories
{
	public interface IBookRepository:IBaseRepository<Book>
	{
		Task<IEnumerable<BookDto>> GetBooksAsync(int page=0,int pageSize=100);
	}
}
