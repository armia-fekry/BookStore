using BookStore.Application.Services.CategoriesServices;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryServices;

		public CategoryController(ICategoryService categoryServices) 
		{
			this._categoryServices = categoryServices;
		}
		// GET: api/<CategoryController>
		[HttpGet]
		public async Task<ActionResult> Get()
		{
			return Ok(await _categoryServices.GetCategories());
		}

		// GET api/<CategoryController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<CategoryController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<CategoryController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<CategoryController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
