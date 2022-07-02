using BookStore.Application.Services.PublisherService.Dto;
using BookStore.Application.Shared;
using BookStore.Domain;

namespace BookStore.Application.Services.PublisherService
{
	public interface IPublisherService
	{
		Task<ApiResponse<Publisher>> GetPublisheByIdAsync(Guid id);
		Task<ApiResponse<Publisher>> GetPublisheByNameAsync(string Name);
		Task<ApiResponse<Publisher>> CreatePublisher(PublisherDto publisher);
		Task<ApiResponse<IEnumerable<Publisher>>> GetPublishersAsync();
		Task<ApiResponse<bool>> DeletePublisher();
	}
}
