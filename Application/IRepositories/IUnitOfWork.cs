namespace BookStore.Application.IRepositories
{
	public interface IUnitOfWork:IDisposable
	{
		public IBookRepository bookRepository { get; }
		public IBookLanguageRepository bookLanguageRepository { get; }
		public IPublisherRepository publisherRepository { get; }
		int Complete();
	}
}
