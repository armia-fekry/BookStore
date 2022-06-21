using System;
using System.Collections.Generic;

namespace BookStore.Domain
{
    public partial class CustOrder
    {
        public CustOrder()
        {
            OrderHistories = new HashSet<OrderHistory>();
            OrderLines = new HashSet<OrderLine>();
        }

        public Guid OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? ShippingMethodId { get; set; }
        public Guid? DestAddressId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Address? DestAddress { get; set; }
        public virtual ShippingMethod? ShippingMethod { get; set; }
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
