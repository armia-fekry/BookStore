using AutoMapper;
using BookStore.Application.IRepositories;
using BookStore.Application.Services.CategoriesServices.Dto;
using BookStore.Application.Shared;

namespace BookStore.Application.Services.CategoriesServices
{
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CategoryService(IUnitOfWork unitOfWork,IMapper mapper)
		{
			this._unitOfWork = unitOfWork;
			this._mapper = mapper;
		}
		public async Task<ApiResponse<IList<CategoryDto>>> GetCategories()
		{
			var result = new ApiResponse<IList<CategoryDto>>();
			try
			{
				var categories = await _unitOfWork.categoryRepository.GetAllAsync();
				result.Result = _mapper.Map<IList<CategoryDto>>(categories);
				result.Succeeded = true;

			}
			catch (Exception ex)
			{
				result.Errors = Helper.FormatException(ex.Message, ex.StackTrace);
			}
			return result;
		}
	}
}
