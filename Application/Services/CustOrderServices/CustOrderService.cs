using BookStore.Application.IRepositories;
using BookStore.Application.Services.CustOrderServices.Dto;
using BookStore.Application.Shared;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Services.CustOrderServices
{
	public class CustOrderService : ICustOrderService
	{
		private readonly IUnitOfWork _unitOfWork;

		public CustOrderService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
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
	}
}
