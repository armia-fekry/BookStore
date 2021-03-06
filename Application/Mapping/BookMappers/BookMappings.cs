using AutoMapper;
using BookStore.Application.Services.BooksServices.Dto;
using BookStore.Application.Shared;
using BookStore.Domain;

namespace BookStore.Application.Mapping.BookMappers
{
	public class BookMappings:Profile
	{
		public BookMappings()
		{
			CreateMap<Book, BookDto>()
				.ForMember(dto => dto.Title, model => model.MapFrom(e => e.Title))
				.ForMember(dto => dto.ImgPath, model => model.MapFrom(e => e.Path))
				.ForMember(dto => dto.Price, model => model.MapFrom(e => e.Price))
				.ForMember(dto => dto.Reviews, model => model.MapFrom(e => e.Reviews))
				.ForMember(dto => dto.Description, model => model.MapFrom(e => e.Description))
				.ForMember(dto => dto.NumPages, model => model.MapFrom(e => e.NumPages))
				.ForMember(dto => dto.CategoryId, model => model.MapFrom(e => e.Category.CategotyId))
				.ForMember(dto => dto.CategoryName, model => model.MapFrom(e => e.Category.CategoryName))
				.ForMember(dto => dto.BookId, model => model.MapFrom(e => e.BookId))
				.ForMember(dto => dto.Authers, model => model.MapFrom(e => Helper.ExtractAuthersNames(e.Authors.ToList())));
		}
	}
}
