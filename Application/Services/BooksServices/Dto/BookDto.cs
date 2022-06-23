namespace BookStore.Application.Services.BooksServices.Dto
{
	public class BookDto
	{
		public string BookId { get; set; }
		public string? Title { get; set; }
		public int? NumPages { get; set; }
		public string BookLanguage { get; set; }
		public string Publisher { get; set; }
		public string? Authers { get; set; }
		public string? Img  { get; set; }
	}
}
