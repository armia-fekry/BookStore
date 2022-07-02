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
	public class CustomerAdressesRepository:BaseRepository<CustomerAddress>, ICustomerAdressesRepository
	{

		public CustomerAdressesRepository(BookStoreContext context) : base(context)
		{
		}
	}
}
