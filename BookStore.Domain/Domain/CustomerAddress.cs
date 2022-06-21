using System;
using System.Collections.Generic;

namespace BookStore.Domain
{
    public partial class CustomerAddress
    {
        public Guid CustomerId { get; set; }
        public Guid AddressId { get; set; }
        public Guid? StatusId { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual AddressStatus? Status { get; set; }
    }
}
