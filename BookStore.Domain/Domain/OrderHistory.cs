using System;
using System.Collections.Generic;

namespace BookStore.Domain
{
    public partial class OrderHistory
    {
		public OrderHistory() { }
		
		private OrderHistory(Guid historyId,
			DateTime? statusDate,
			CustOrder? order = null, 
			OrderStatus? status = null)
		{
			HistoryId = historyId;
			StatusDate = statusDate;
			Order = order;
			Status = status;
		}
		public static OrderHistory Create(Guid historyId,
			DateTime? statusDate,
			CustOrder? order = null,
			OrderStatus? status = null)
			=> new(Guid.NewGuid(), statusDate, order, status);
		public Guid HistoryId { get; set; }
		public Guid? OrderId { get; set; }
        public Guid? StatusId { get; set; }
        public DateTime? StatusDate { get; set; }

        public virtual CustOrder? Order { get; set; }
        public virtual OrderStatus? Status { get; set; }
    }
}
