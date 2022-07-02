using BookStore.Application.IRepositories;
using BookStore.Domain;
using BookStore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repositories
{
	public class CustomerRepository:BaseRepository<Customer>, ICustomerRepository
	{
		public CustomerRepository(BookStoreContext context) : base(context)
		{

		}
	}
}
