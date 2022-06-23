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

		private CustOrder(Guid orderId,
            DateTime? orderDate, 
            Customer? customer, 
            Address? destAddress,
            ShippingMethod? shippingMethod, 
            ICollection<OrderHistory> orderHistories, 
            ICollection<OrderLine> orderLines)
		{
			OrderId = orderId;
			OrderDate = orderDate;
			Customer = customer;
			DestAddress = destAddress;
			ShippingMethod = shippingMethod;
			OrderHistories = orderHistories;
			OrderLines = orderLines;
		}
        public static CustOrder Create(DateTime? orderDate,
            Customer? customer,
            Address? destAddress, 
            ShippingMethod? shippingMethod,
            ICollection<OrderHistory> orderHistories,
            ICollection<OrderLine> orderLines)
        => new (Guid.NewGuid(), orderDate, customer,
            destAddress, shippingMethod, orderHistories, orderLines);
        

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
