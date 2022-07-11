using BookStore.Application.Services.CustOrderServices.Dto;
using BookStore.Application.Shared;

namespace BookStore.Application.Services.CustOrderServices
{
	public interface ICustOrderService
	{
		Task<ApiResponse<CustOrderDto>> AddCustorder(CreateCustOrderDto createCustOrderDto);
		Task<ApiResponse<IList<ShippingMethodDto>>> ShippingMethod();
	}
}
