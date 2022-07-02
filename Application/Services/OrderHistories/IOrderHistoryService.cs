using BookStore.Application.Shared;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Services.OrderHistories
{
	public interface IOrderHistoryService
	{
		Task<ApiResponse<IEnumerable<OrderhistoryDto>>> GetAllCustomerOrdersHistory(Guid CustId);
	}
}
