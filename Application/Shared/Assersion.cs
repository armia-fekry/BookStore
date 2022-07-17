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

		internal static void AgainstGuid(Guid id, string v)
		{
			if (id == Guid.Empty)
				throw new InvalidDataException(v);
		}

		internal static void AgainstNullOrEmpty(string categoryName, string v)
		{
			if(string.IsNullOrEmpty(categoryName))
				throw new ArgumentNullException(categoryName);
		}
	}
}
