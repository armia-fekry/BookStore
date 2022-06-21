namespace BookStore.Application.Shared
{
	public static class Helper
	{
		public static string FormatException(string message, string? stackTrace)
		=>string.Format("Errors Happened ..Message {0} /n StackTrace {1}",message, stackTrace);
	}
}
