using System;
using System.Collections.Generic;

namespace BookStore.Domain
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public Guid PublisherId { get; set; }
        public string? PublisherName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
