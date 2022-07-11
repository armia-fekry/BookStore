using AutoMapper;
using BookStore.Application.Services.CustOrderServices.Dto;
using BookStore.Domain;

namespace BookStore.Application.Mapping.OrderHistoryMappers
{
	public class ShippingMethodMapping:Profile
	{
		public ShippingMethodMapping()
		{
			CreateMap<ShippingMethod, ShippingMethodDto>()
				.ForMember(dto => dto.id, model => model.MapFrom(e => e.MethodId))
				.ForMember(dto => dto.Name, model => model.MapFrom(e => e.MethodName))
				.ForMember(dto => dto.Cost, model => model.MapFrom(e => e.Cost));
		}
	}
}
