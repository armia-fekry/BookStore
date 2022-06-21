using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BookStore.Domain
{
    public partial class Book
    {
        public Book()
        {
            OrderLines = new HashSet<OrderLine>();
            Authors = new HashSet<Author>();
        }

        public Guid BookId { get; set; }
        public string? Title { get; set; }
        public string? Isbn13 { get; set; }
        public Guid? LanguageId { get; set; }
        public int? NumPages { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Guid? PublisherId { get; set; }
		public string? Path { get; set; }
        [JsonIgnore]
		public virtual BookLanguage? Language { get; set; }
        [JsonIgnore]

        public virtual Publisher? Publisher { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
