using System.Drawing;
namespace BookStore.Application.Shared
{
	public static class Helper
	{
		public static string FormatException(string message, string? stackTrace)
		=>string.Format("Errors Happened ..Message {0} /n StackTrace {1}",message, stackTrace);


        public static string ImageToBase64(string path)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(path);
            return Convert.ToBase64String(imageArray);
        }
    }
}
