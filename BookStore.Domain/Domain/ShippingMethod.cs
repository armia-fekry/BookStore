using System;
using System.Collections.Generic;

namespace BookStore.Domain
{
    public partial class ShippingMethod
    {
        public ShippingMethod()
        {
            CustOrders = new HashSet<CustOrder>();
        }

        public Guid MethodId { get; set; }
        public string? MethodName { get; set; }
        public decimal? Cost { get; set; }

        public virtual ICollection<CustOrder> CustOrders { get; set; }
    }
}
