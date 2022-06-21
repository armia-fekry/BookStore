using System;
using System.Collections.Generic;

namespace BookStore.Domain
{
    public partial class AddressStatus
    {
        public AddressStatus()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
        }

        public Guid StatusId { get; set; }
        public string? AddressStatus1 { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
