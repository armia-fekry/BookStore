using BookStore.Application.Services.CategoriesServices.Dto;
using BookStore.Application.Shared;

namespace BookStore.Application.Services.CategoriesServices
{
	public interface ICategoryService
	{
		Task<ApiResponse<IList<CategoryDto>>> GetCategories();

	}
}
