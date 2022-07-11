using back.Services;
using Microsoft.AspNetCore.SignalR;

namespace back.Hubs
{
	public class ChatHub : Hub<IChatHubClient>
	{
		private ChatManager ChatManager { get; }
		public ChatHub(ChatManager chatManager)
		{
			this.ChatManager = chatManager;
		}

		#region Connect/Disconnect
		public override Task OnConnectedAsync()
		{
			
			return base.OnConnectedAsync();
		}
		public override Task OnDisconnectedAsync(Exception? exception)
		{
			return base.OnDisconnectedAsync(exception);
		}
		#endregion
	}
}
