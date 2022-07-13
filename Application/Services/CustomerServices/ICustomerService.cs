using BookStore.Application.Services.CustomerServices.Dto;
using BookStore.Application.Shared;

namespace BookStore.Application.Services.CustomerServices
{
	public interface ICustomerService
	{
		Task<ApiResponse<CustomerlogInResult>> LogIn(customerloginDto logInDto);
	}
}
