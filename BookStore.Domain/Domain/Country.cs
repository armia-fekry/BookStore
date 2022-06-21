using BookStore.Domain;
using System;
using System.Collections.Generic;

namespace BookStore.Infrastructure.Models
{
    public partial class Country
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
        }

        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
