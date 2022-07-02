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
            OrderHistory orderHistories,
            OrderLine orderLines)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            Customer = customer;
            DestAddress = destAddress;
            ShippingMethod = shippingMethod;
            AddToOrderLines(orderLines);
            AddToOrderHistories(orderHistories);
        }
        public static CustOrder Create(DateTime? orderDate,
            Customer? customer,
            Address? destAddress,
            ShippingMethod? shippingMethod,
            OrderHistory orderHistory,
            OrderLine orderLine)
        => new(Guid.NewGuid(), orderDate, customer,
            destAddress, shippingMethod, orderHistory, orderLine);


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
        private void AddToOrderLines(OrderLine orderLine)
        {
            if (orderLine != null)
                OrderLines.Add(orderLine);
        }
        private void AddToOrderHistories(OrderHistory orderHistory)
        {
            if(orderHistory != null)
                OrderHistories.Add(orderHistory);
        }

    }
}
