using BookStore.Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace BookStore.Domain
{
    public partial class Address
    {
        public Address()
        {
            CustOrders = new HashSet<CustOrder>();
            CustomerAddresses = new HashSet<CustomerAddress>();
        }

        public Guid AddressId { get; set; }
        public string? StreetNumber { get; set; }
        public string? StreetName { get; set; }
        public string? City { get; set; }
        public Guid? CountryId { get; set; }

        public virtual Country? Country { get; set; }
        public virtual ICollection<CustOrder> CustOrders { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
