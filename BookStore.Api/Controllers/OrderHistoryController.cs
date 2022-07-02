using BookStore.Application.Services.OrderHistories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderHistoryController : ControllerBase
	{
		private readonly IOrderHistoryService _orderHistoryService;

		public OrderHistoryController(IOrderHistoryService orderHistoryService)
		{
			this._orderHistoryService = orderHistoryService;
		}
		// GET: api/<OrderHistoryController>
		[HttpGet]
		public async Task<ActionResult> Get(string CustomerId)
		{
			return Ok(await _orderHistoryService.GetAllCustomerOrdersHistory(Guid.Parse(CustomerId)));
		}

		// GET api/<OrderHistoryController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<OrderHistoryController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<OrderHistoryController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<OrderHistoryController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
