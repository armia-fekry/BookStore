using AutoMapper;
using BookStore.Application.Services.CustomerServices.Dto;
using BookStore.Domain;

namespace BookStore.Application.Mapping.CustomerMappers
{
	public class CustomerMapper:Profile
	{
		public CustomerMapper()
		{
			CreateMap<Customer, CustomerlogInResult>()
				.ForMember(dto => dto.Id, model => model.MapFrom(e => e.CustomerId.ToString()))
				.ForMember(dto => dto.customerName, model => model.MapFrom(e => $"{e.FirstName} {e.LastName}"));
		}
	}
}
