using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.Services.CustomerServices.Dto
{
	public class customerloginDto
	{
		[Required(ErrorMessage ="Invalid User Name")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Invalid Password")]
		public string PassWod { get; set; }
	}
}
