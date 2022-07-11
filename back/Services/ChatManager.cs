using back.Contexts;
using back.Models;

namespace back.Services
{
	public class ChatManager
	{
		public SynchronizedCollection<ChatUser> ChatUsers { get; }

		public Action? OnUserAdd;
		public Action? OnUserRemove;
		public ChatManager()
		{
			this.ChatUsers = new SynchronizedCollection<ChatUser>();
		}

		public ChatUser? GetChatUserById(int id) => this.ChatUsers.FirstOrDefault(u => u.Id == id);
		public void AddChatUser(int id)
		{
			if (IsChatUserInCollection(id)) return;

			User? user;
			using (DataContext context = new DataContext())
			{
				user = context.Users.ToArray().FirstOrDefault(u => u.Id == id);
			}
			if (user is null) return;

			this.ChatUsers.Add(new ChatUser
			{
				Id = user.Id,
				Username = user.Username,
				AvatarUrl = user.AvatarUrl
			});
			OnUserAdd?.Invoke();
		}
		public void RemoveChatUser(ChatUser user)
		{
			this.ChatUsers.Remove(user);
			OnUserRemove?.Invoke();
		}

		private bool IsChatUserInCollection(int id)
		{
			if (GetChatUserById(id) is not null) return true;
			return false;
		}


	}
}
