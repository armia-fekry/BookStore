using AutoMapper;
using BookStore.Application.Services.CategoriesServices.Dto;
using BookStore.Domain.Domain;

namespace BookStore.Application.Mapping.CategoryMappers
{
	public class CategoryMapper:Profile
	{
		public CategoryMapper()
		{
			CreateMap<Category, CategoryDto>()
				.ForMember(dto=>dto.CategoryId,model=>model.MapFrom(e=>e.CategotyId))
				.ForMember(dto=>dto.CategoryName,model=>model.MapFrom(e=>e.CategoryName))
				.ReverseMap();
		}
	}
}
