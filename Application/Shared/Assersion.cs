namespace BookStore.Application.Shared
{
	public static class Assersion
	{
		public static void AgainstNull(object value, string message)
		{
			if(value is null)
				throw new ArgumentNullException(message);
		}
		public static void AgainstManyNull(string message,params object[] values)
		{
			if(values.All(x => x == null))
				throw new ArgumentException(message);
		}
	}
}
