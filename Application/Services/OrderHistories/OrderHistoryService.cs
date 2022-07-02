using AutoMapper;
using BookStore.Application.IRepositories;
using BookStore.Application.Shared;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Services.OrderHistories
{
	public class OrderHistoryService : IOrderHistoryService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public OrderHistoryService(IUnitOfWork unitOfWork,IMapper mapper)
		{
			this._unitOfWork = unitOfWork;
			this._mapper = mapper;
		}
		public async Task<ApiResponse<IEnumerable<OrderhistoryDto>>> GetAllCustomerOrdersHistory(Guid CustId)
		{
			var result = new ApiResponse<IEnumerable<OrderhistoryDto>>();
			try
			{
				Assersion.AgainstNull(CustId, "Invalid Customer");
				var orderhistories = await _unitOfWork.orderHistoryRepository.FindAllAsync(e=>e.Order.CustomerId==CustId,new string []{ "Order" });
				result.Result= _mapper.Map<IEnumerable<OrderhistoryDto>>(orderhistories);
				result.Succeeded = true;
			}
			catch (Exception ex)
			{
				result.Errors = Helper.FormatException(ex.Message, ex.Source);
			}
			return result;
		}
	}
}
