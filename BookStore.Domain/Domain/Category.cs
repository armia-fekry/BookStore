using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Domain
{
	public partial class Category
	{
		public Category()
		{
			Books=new HashSet<Book>();
		}
		public Guid CategotyId { get; set; }
		public string CategoryName { get; set; }
		public virtual ICollection<Book> Books { get; set; }
	}
}
