using System;
using System.Collections.Generic;

namespace BookStore.Domain
{
    public partial class OrderLine
    {
        public Guid LineId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? BookId { get; set; }
        public decimal? Price { get; set; }

        public virtual Book? Book { get; set; }
        public virtual CustOrder? Order { get; set; }
    }
}
