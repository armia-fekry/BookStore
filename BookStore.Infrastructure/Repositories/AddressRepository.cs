using BookStore.Application.IRepositories;
using BookStore.Domain;
using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure.Repositories
{
	public class AddressRepository:BaseRepository<Address>,IAdressesRepository
	{
		public AddressRepository(BookStoreContext context) : base(context)
		{
			
		}
	
	}
}
