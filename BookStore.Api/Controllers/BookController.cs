﻿using BookStore.Application.Services.BooksServices;
using BookStore.Application.Services.BooksServices.Dto;
using BookStore.Application.Shared;
using BookStore.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private readonly IBookService _bookService;

		public BookController(IBookService bookService)
		{
			this._bookService = bookService;
		}
		// GET: api/<BookController>
		[HttpGet]
		public async Task<IEnumerable<object>> Get()
		{
			return await _bookService.GetAll();
		}

		// GET api/<BookController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<BookController>
		[HttpPost]
		public async Task<ApiResponse<Book>> Post([FromBody] BookCreateDto bookCreateDto)
		{
			return await _bookService.AddBookAsync(bookCreateDto);
		}

		// PUT api/<BookController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<BookController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			return Ok(_bookService.DeleteBook(id));
		}
	}
}
