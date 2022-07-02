using BookStore.Application.Services.CustOrderServices.Dto;
using BookStore.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Services.CustOrderServices
{
	public interface ICustOrderService
	{
		Task<ApiResponse<CustOrderDto>> AddCustorder(CreateCustOrderDto createCustOrderDto);
	}
}
