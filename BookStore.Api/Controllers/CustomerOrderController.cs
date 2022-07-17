using BookStore.Application.Services.CustomerServices;
using BookStore.Application.Services.CustomerServices.Dto;
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
		private readonly ICustomerService _customerService;

		public CustomerOrderController(ICustOrderService custOrderService,ICustomerService customerService)
		{
			this._custOrderService = custOrderService;
			this._customerService = customerService;
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
		[HttpGet("shippingMethods")]
		public async Task<ActionResult> GetShippingMethods()
		{
			return Ok(await _custOrderService.ShippingMethod());
		}
		[HttpPost("LogIn")]
		public async Task<ActionResult> LogIn([FromBody] customerloginDto customerlogin)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState.ValidationState);
			return Ok(await _customerService.LogIn(customerlogin));
		}
	}
}
