using BookStore.Application.IRepositories;
using BookStore.Application.Services.LanguagesServices.Dto;
using BookStore.Application.Shared;
using BookStore.Domain;

namespace BookStore.Application.Services.LanguagesServices
{
	public class LanguageService : ILanguageService
	{
		private readonly IUnitOfWork _unitOfWork;

		public LanguageService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}
	
		public async Task<ApiResponse<BookLanguage>> Add(LanguageDto bookLanguage)
		{
			var result = new ApiResponse<BookLanguage>();
			try
			{
				var newBookLanguage = new BookLanguage()
				{
					LanguageCode = bookLanguage.LanguageCode
					,
					LanguageName = bookLanguage.LanguageTitle
				};

				result.Result = _unitOfWork.bookLanguageRepository.Add(newBookLanguage);
				result.Succeeded = true;
			}
			catch (Exception ex)
			{
				result.Errors = Helper.FormatException(ex.Message,ex.StackTrace);
			}
			return await Task.FromResult(result);
		}

		public async Task<ApiResponse<IEnumerable<BookLanguage>>> GetAllAsync()
		{
			var result = new ApiResponse<IEnumerable<BookLanguage>>();
			try
			{
				result.Result=await _unitOfWork.bookLanguageRepository.GetAllAsync();
				result.Succeeded=true;

			}
			catch (Exception ex)
			{
				result.Errors = Helper.FormatException(ex.Message, ex.StackTrace);
			}
			return await Task.FromResult(result);
		}

		public async Task<ApiResponse<BookLanguage>> GetAsync(Guid id)
		{
			var result = new ApiResponse<BookLanguage>();
			try
			{
				result.Result=await _unitOfWork.bookLanguageRepository
												.FindAsync(e => e.LanguageId == id);
				result.Succeeded = true;

			}
			catch (Exception ex)
			{
				result.Errors = Helper.FormatException(ex.Message, ex.StackTrace);
			}
			return await Task.FromResult(result);

		}

		public async Task<ApiResponse<BookLanguage>> GetOrCreateBookLanguage(Guid? LanguageId, LanguageDto book)
		{
			var result = new ApiResponse<BookLanguage>();
			try
			{
				if (LanguageId.HasValue)
				{
					return await GetAsync(LanguageId.Value);
				}
				if (book is not null)
				{
					return await Add(book);
				}
			}
			catch (Exception ex)
			{
				result.Errors=Helper.FormatException(ex.Message, ex.StackTrace);
			}
			return await Task.FromResult(result);
		}
	}
}
