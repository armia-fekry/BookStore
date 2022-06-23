using BookStore.Domain;
using System.Drawing;
namespace BookStore.Application.Shared
{
	public static class Helper
	{
		public static string FormatException(string message, string? stackTrace)
		=>string.Format("Errors Happened ..Message {0} /n StackTrace {1}",message, stackTrace);


        public static string ImageToBase64(string path)
        {
            if(string.IsNullOrEmpty(path))
                return string.Empty;
            string _path = @$"{Directory.GetCurrentDirectory()}\ImgFiles\{path}";
            if (!File.Exists(_path))
                return string.Empty;

            byte[] imageArray = System.IO.File.ReadAllBytes(_path);
            return Convert.ToBase64String(imageArray);
        }
        public static string ExtractAuthersNames(IList<Author> authers)
        {
            if (authers is not null && authers.Count > 0)
                return string.Join(',', authers.Select(e => e.AuthorName).ToArray());
            return string.Empty;
        }
    }
}
