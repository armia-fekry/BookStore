using BookStore.Application.Services.LanguagesServices.Dto;
using BookStore.Application.Shared;
using BookStore.Domain;

namespace BookStore.Application.Services.LanguagesServices
{
	public interface ILanguageService
	{
		Task<ApiResponse<IEnumerable<BookLanguage>>> GetAllAsync();
		Task<ApiResponse<BookLanguage>> GetAsync(Guid id);
		Task<ApiResponse<BookLanguage>> Add(LanguageDto book);
		Task<ApiResponse<BookLanguage>> GetOrCreateBookLanguage(Guid? LanguageId,LanguageDto book);
	}
}
