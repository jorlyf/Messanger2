using System.Text.Json;

namespace back
{
	public static class Utils
	{
		public static long TotalSecondsNow
		{
			get => (long)TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds;
		}
		public static string Serialize(object obj)
		{
			return JsonSerializer.Serialize(obj);
		}
		public static T? Deserialize<T>(string json) where T : class
		{
			try
			{
				T? result = JsonSerializer.Deserialize<T>(json);
				return result;
			}
			catch (JsonException ex)
			{
				Console.WriteLine("Не удалось десереализовать json");
				Console.WriteLine(ex.Message);
				return null;
			}
		}
	}
}
