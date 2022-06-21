using System;
using System.Collections.Generic;

namespace BookStore.Domain
{
    public partial class OrderHistory
    {
        public Guid HistoryId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? StatusId { get; set; }
        public DateTime? StatusDate { get; set; }

        public virtual CustOrder? Order { get; set; }
        public virtual OrderStatus? Status { get; set; }
    }
}
