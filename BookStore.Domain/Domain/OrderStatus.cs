using System;
using System.Collections.Generic;

namespace BookStore.Domain
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            OrderHistories = new HashSet<OrderHistory>();
        }

        public Guid StatusId { get; set; }
        public string? StatusValue { get; set; }

        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}
