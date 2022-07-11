using AutoMapper;
using BookStore.Application.IRepositories;
using BookStore.Application.Services.CustOrderServices.Dto;
using BookStore.Application.Shared;
using BookStore.Domain;

namespace BookStore.Application.Services.CustOrderServices
{
	public class CustOrderService : ICustOrderService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CustOrderService(IUnitOfWork unitOfWork,IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async  Task<ApiResponse<CustOrderDto>> AddCustorder(CreateCustOrderDto createCustOrderDto)
		{
			try
			{
				Assersion.AgainstNull(createCustOrderDto, "Invalid Request");
				Assersion.AgainstNull(createCustOrderDto.CustomerId, "Invalid Customer Id");
				var shippingMethod =  _unitOfWork.shippingMethodRepository.GetById(Guid.Parse(createCustOrderDto.ShippingMethod));
				var book = _unitOfWork.bookRepository.GetById(Guid.Parse(createCustOrderDto.BookId));
				var customer =  _unitOfWork.customerRepository.GetById(Guid.Parse(createCustOrderDto.CustomerId));
				var custAdress =  _unitOfWork.customerAdressesRepository.Find(e => e.CustomerId == Guid.Parse(createCustOrderDto.CustomerId), new string[] { "Address" });
				var custOrder = CustOrder.Create(DateTime.Now, customer, custAdress.Address, shippingMethod, null, null);
				var CustOrderResult = _unitOfWork.custOrderRepository.Add(custOrder);
				var price = book.Price + shippingMethod.Cost;
				var orderLine = OrderLine.Create(Guid.NewGuid(), price, book, custOrder);
					_unitOfWork.orderLineRepository.Add(orderLine);
					_unitOfWork.Complete();
				
				return null;
			}
			catch (Exception ex)
			{
				return null;
			}
			
		}

		public async Task<ApiResponse<IList<ShippingMethodDto>>> ShippingMethod()
		{
			var result= new ApiResponse<IList<ShippingMethodDto>>();
			try
			{
				var methods=await _unitOfWork.shippingMethodRepository.GetAllAsync();
				result.Result = _mapper.Map<IList<ShippingMethodDto>>(methods);
				result.Succeeded = true;
			}
			catch (Exception ex )
			{
				result.Errors = Helper.FormatException(ex.Message, ex.StackTrace);
			}
			return result;
		}
	}
}
