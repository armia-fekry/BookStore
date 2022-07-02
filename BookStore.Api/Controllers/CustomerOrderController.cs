using BookStore.Application.Services.CustOrderServices;
using BookStore.Application.Services.CustOrderServices.Dto;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerOrderController : ControllerBase
	{
		private readonly ICustOrderService _custOrderService;

		public CustomerOrderController(ICustOrderService custOrderService)
		{
			this._custOrderService = custOrderService;
		}
		// GET: api/<CustomerOrderController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<CustomerOrderController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<CustomerOrderController>
		[HttpPost]
		public ActionResult Post([FromBody] CreateCustOrderDto custOrderDto)
		{
			return Ok(_custOrderService.AddCustorder(custOrderDto));
		}

		// PUT api/<CustomerOrderController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<CustomerOrderController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
