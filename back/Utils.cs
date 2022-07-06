namespace back
{
	public static class Utils
	{
		public static long TotalSecondsNow
		{
			get => (long)TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds;
		}
	}
}
