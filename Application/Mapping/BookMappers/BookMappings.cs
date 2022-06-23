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
				.ForMember(dto => dto.NumPages, model => model.MapFrom(e => e.NumPages))
				.ForMember(dto => dto.BookId, model => model.MapFrom(e => e.BookId))
				.ForMember(dto => dto.Authers, model => model.MapFrom(e => Helper.ExtractAuthersNames(e.Authors.ToList())))
				.ForMember(dto => dto.Img, model => model.MapFrom(e => Helper.ImageToBase64(e.Path)))
				.ForMember(dto => dto.BookLanguage, model => model.MapFrom(e => e.Language.LanguageName));
		}
	}
}
