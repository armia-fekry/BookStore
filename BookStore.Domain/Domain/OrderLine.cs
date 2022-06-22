using System;
using System.Collections.Generic;

namespace BookStore.Domain
{
    public partial class OrderLine
    {
        public OrderLine() { }
        private OrderLine(Guid lineId,decimal? price,Book? book,CustOrder? custOrder)
        {
            LineId = lineId;
            Price = price;
            Book = book;
            Order = custOrder;
        }
        public static OrderLine Create(Guid lineId,
            decimal? price,
            Book? book,
            CustOrder? custOrder)
            => new (Guid.NewGuid(),price,book,custOrder);
        public Guid LineId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? BookId { get; set; }
        public decimal? Price { get; set; }

        public virtual Book? Book { get; set; }
        public virtual CustOrder? Order { get; set; }
    }
}
