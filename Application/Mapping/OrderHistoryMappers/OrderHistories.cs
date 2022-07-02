using AutoMapper;
using BookStore.Application.Services.OrderHistories;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Mapping.OrderHistoryMappers
{
	public class OrderHistories:Profile
	{
		public OrderHistories()
		{
			CreateMap<OrderHistory, OrderhistoryDto>()
				.ForMember(dto => dto.StatusId, model => model.MapFrom(e => e.StatusId));
		}
	}
}
