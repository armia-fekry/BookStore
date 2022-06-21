namespace BookStore.Application.Shared
{
	public class ApiResponse<T>
	{
		public T Result { get; set; }
		public string Errors { get; set; }
		public bool Succeeded { get; set; }=false;
	}
}
