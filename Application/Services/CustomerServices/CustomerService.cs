using AutoMapper;
using BookStore.Application.IRepositories;
using BookStore.Application.Services.CustomerServices.Dto;
using BookStore.Application.Shared;

namespace BookStore.Application.Services.CustomerServices
{
	public class CustomerService : ICustomerService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CustomerService(IUnitOfWork unitOfWork,IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<ApiResponse<CustomerlogInResult>> LogIn(customerloginDto logInDto)
		{
			var response = new ApiResponse<CustomerlogInResult>();
			try
			{
				var customer = await _unitOfWork.customerRepository
						.FindAsync(e => e.Email == logInDto.Email && e.PassWord == logInDto.Password);
				if (customer == null)
				{
					response.Errors = "Invalid Email Or Password";
				}
				else
				{
					var cust_address = await _unitOfWork.customerAdressesRepository.FindAsync(e => e.CustomerId == customer.CustomerId);
					var adress = await _unitOfWork.adressesRepository.FindAsync(e => e.AddressId == cust_address.AddressId, new string[] { "Country" });
					var adressDto = new AdressDto()
						{
							street = adress.StreetName,
							city = adress.City,
							country = adress.Country.CountryName
						};
					response.Result = _mapper.Map<CustomerlogInResult>(customer);
					response.Result.adress = adressDto;
					response.Succeeded = true;
				}
			}
			catch (Exception ex)
			{
				response.Errors = Helper.FormatException(ex.Message, ex.StackTrace);

			}
			return response;
			
		}
	}
}
