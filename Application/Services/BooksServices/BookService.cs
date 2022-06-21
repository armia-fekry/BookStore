using BookStore.Application.IRepositories;
using BookStore.Application.Services.BooksServices.Dto;
using BookStore.Application.Services.LanguagesServices;
using BookStore.Application.Services.LanguagesServices.Dto;
using BookStore.Application.Services.PublisherService;
using BookStore.Application.Services.PublisherService.Dto;
using BookStore.Application.Shared;
using BookStore.Domain;

namespace BookStore.Application.Services.BooksServices
{
	public class BookService : IBookService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILanguageService _languageService;
		private readonly IPublisherService _publisherService;

		public BookService(IUnitOfWork unitOfWork,ILanguageService languageService,
							IPublisherService publisherService)
		{
			_unitOfWork = unitOfWork;
			this._languageService = languageService;
			this._publisherService = publisherService;
		}
		public async Task<ApiResponse<Book>> AddBookAsync(BookCreateDto bookDto)
		{
			var result = new ApiResponse<Book>();
			try
			{
				var book = new Book();
				Assersion.AgainstManyNull("Invalid Or Empty Language Of The Book",
										bookDto.LanguageId, bookDto.Language);
				Assersion.AgainstManyNull("Invalid Or Empty Publisher Id..",
										bookDto.PublisherId, bookDto.PublisherName);
				var bookLanguage = await _languageService.GetOrCreateBookLanguage(bookDto.LanguageId, bookDto.Language);
				//book.PublisherId = await HandleBookPublisher(bookDto.PublisherId, bookDto.PublisherName);
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
		
		public bool DeleteBook(int id)
		{
			var book = _unitOfWork.bookRepository.GetById(id);
			if (book == null)
				return false;
			_unitOfWork.bookRepository.Delete(book);
			return true;
		}

		public async Task<IEnumerable<BookDto>> GetAll(int page=0, int pageSize = 100)
					=> await _unitOfWork.bookRepository
										.GetBooksAsync(page, pageSize);

		public Task<Book> GetBookByIdAsync(int id)
		{

			throw new NotImplementedException();
		}

		public Task<Book> GetBookByNameAsync(string name)
		{
			throw new NotImplementedException();
		}
	}
}
