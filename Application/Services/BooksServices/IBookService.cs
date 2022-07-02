using BookStore.Application.Services.BooksServices.Dto;
using BookStore.Application.Shared;
using BookStore.Domain;

namespace BookStore.Application.Services.BooksServices
{
	public interface IBookService
	{
		Task<IEnumerable<BookDto>> GetAll(int page=0,int pageSize=100);
		Task<Book> GetBookByIdAsync(Guid id);
		Task<Book> GetBookByNameAsync(string name);
		bool DeleteBook(Guid id);
		Task<ApiResponse<Book>> AddBookAsync(BookCreateDto book);
	}
}
