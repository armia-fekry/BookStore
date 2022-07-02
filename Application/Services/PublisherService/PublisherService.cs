using BookStore.Application.IRepositories;
using BookStore.Application.Services.PublisherService.Dto;
using BookStore.Application.Shared;
using BookStore.Domain;

namespace BookStore.Application.Services.PublisherService
{
	public class PublisherService : IPublisherService
	{
		private readonly IUnitOfWork _unitOfWork;

		public PublisherService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}
		public async Task<ApiResponse<Publisher>> CreatePublisher(PublisherDto publisher)
		{
			var result = new ApiResponse<Publisher>();
			try
			{
				Assersion.AgainstNull(publisher.PublisherName, "Invalid Publisher Name..");
				var newPublisher = new Publisher()
				{
					PublisherName = publisher.PublisherName,
				};

				result.Result=_unitOfWork.publisherRepository.Add(newPublisher);
				result.Succeeded = true;
			}
			catch (Exception ex)
			{
				result.Errors = Helper.FormatException(ex.Message, ex.StackTrace);
			}
			return await Task.FromResult(result);		
		}

		public Task<ApiResponse<bool>> DeletePublisher()
		{
			throw new NotImplementedException();
		}

		public async Task<ApiResponse<Publisher>> GetPublisheByIdAsync(Guid id)
		{
			var result = new ApiResponse<Publisher>();
			try
			{
				Assersion.AgainstNull(id, "Publisher Id Is empty ...");
				result.Result=await _unitOfWork.publisherRepository.GetByIdAsync(id);
				result.Succeeded=true;
			}
			catch (Exception ex)
			{
				result.Errors = Helper.FormatException(ex.Message, ex.StackTrace);
			}
			return await Task.FromResult(result);
		}

		public Task<ApiResponse<Publisher>> GetPublisheByNameAsync(string Name)
		{
			throw new NotImplementedException();
		}

		public async Task<ApiResponse<IEnumerable<Publisher>>> GetPublishersAsync()
		{
			var response= new ApiResponse<IEnumerable<Publisher>>();
			try
			{
				response.Result=await _unitOfWork.publisherRepository.GetAllAsync();
				response.Succeeded = true;
			}
			catch (Exception ex)
			{
				response.Errors = Helper.FormatException(ex.Message, ex.StackTrace);
			}
			return response;
		}
	}
}
