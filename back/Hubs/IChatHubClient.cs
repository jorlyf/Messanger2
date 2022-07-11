namespace back.Hubs
{
	public interface IChatHubClient
	{
		public Task ReceiveMessage(string message);
	}
}
