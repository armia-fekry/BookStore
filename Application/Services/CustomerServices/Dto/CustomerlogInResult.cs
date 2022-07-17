namespace BookStore.Application.Services.CustomerServices.Dto
{
	public class CustomerlogInResult
	{
		public string customerName { get; set; }
		public string Id { get; set; }
		public AdressDto adress { get; set; }
	}
	public class AdressDto
	{
		public string street { get; set; }
		public string city { get; set; }
		public string country { get; set; }
	}
}
