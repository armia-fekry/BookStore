using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Projection
{
	public class BookProjection
	{
        public int BookId { get; set; }
        public string? Title { get; set; }
        public int? NumPages { get; set; }
        public string? Path { get; set; }
		public string? Authers { get; set; }

	}
}
