using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.Services.BooksServices.Dto
{
	public class BookCreateDto
	{
        public string? Title { get; set; }
        public string? Isbn13 { get; set; }
		public int? NumPages { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Guid? PublisherId { get; set; }
        public string? PublisherName { get; set; }
		public List<int>? Authers { get; set; }
		public List<string>? AuthersNames { get; set; }
		public string? Path { get; set; }

    }
}
