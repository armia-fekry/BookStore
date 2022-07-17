using AutoMapper;
using BookStore.Application.IRepositories;
using BookStore.Application.Services.BooksServices.Dto;
using BookStore.Application.Services.PublisherService;
using BookStore.Application.Shared;
using BookStore.Domain;

namespace BookStore.Application.Services.BooksServices
{
	public class BookService : IBookService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPublisherService _publisherService;
		private readonly IMapper _mapper;

		public BookService(IUnitOfWork unitOfWork,
							IPublisherService publisherService
			, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			this._publisherService = publisherService;
			this._mapper = mapper;
		}
		public async Task<ApiResponse<Book>> AddBookAsync(BookCreateDto bookDto)
		{
			var result = new ApiResponse<Book>();
			try
			{
				var book = new Book();
				Assersion.AgainstManyNull("Invalid Or Empty Publisher Id..",
										bookDto.PublisherId, bookDto.PublisherName);
				book.Title = bookDto.Title;
				book.Isbn13 = bookDto.Isbn13;
				book.NumPages = bookDto.NumPages;

				result.Result=_unitOfWork.bookRepository.Add(book);
				result.Succeeded=true;
				var cc = _unitOfWork.Complete();
			}
			catch (Exception ex)
			{
				
				result.Errors = Helper.FormatException(ex.Message, ex.StackTrace);
			}
			return result;
		}
		
		public bool DeleteBook(Guid id)
		{
			var book = _unitOfWork.bookRepository.GetById(id);
			if (book == null)
				return false;
			_unitOfWork.bookRepository.Delete(book);
			return true;
		}

		public async Task<IEnumerable<BookDto>> GetAll(int page = 0, int pageSize = 100)
		{
			var books = await _unitOfWork.bookRepository
										  .GetBooksAsync(e=>e.BookId!=Guid.Empty,page, pageSize);
			return _mapper.Map <IEnumerable<BookDto>>(books);
		}

		public async Task<ApiResponse<BookDto>> GetBookByIdAsync(Guid id)
		{
			Assersion.AgainstGuid(id, "Invalid Book Id");
			var result = new ApiResponse<BookDto>();
			try
			{
				var book =await _unitOfWork.bookRepository.FindAsync(e=>e.BookId==id,new string[] { "Category" });
				result.Result=_mapper.Map<BookDto>(book);
				result.Succeeded = true;
			}
			catch (Exception ex)
			{
				result.Errors=Helper.FormatException(ex.Message, ex.StackTrace);
			}
			return await Task.FromResult(result);
		}

		public Task<Book> GetBookByNameAsync(string name)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<BookDto>> GetCategorieBooks(string categoryName, int page, int pageSize)
		{
			try
			{
				Assersion.AgainstNullOrEmpty(categoryName, "invalid category Name");
				var category = await _unitOfWork.categoryRepository.FindAsync(e => e.CategoryName == categoryName);
				var books = await _unitOfWork.bookRepository.GetBooksAsync(e=>e.CategotyId==category.CategotyId, page, pageSize);
				return _mapper.Map<IEnumerable<BookDto>>(books);
			}
			catch (Exception)
			{
				return null;
			}

		}
	}
}
