using back.Models;

namespace back.Services
{
	public class UserService
	{
		public List<ChatUser> Users { get; }

		public Action? OnUserAdd;
		public Action? OnUserRemove;
		public UserService()
		{
			this.Users = new List<ChatUser>();
		}

		public ChatUser? GetChatUserById(int id) => this.Users.FirstOrDefault(u => u.Id == id);
		public void AddUser(int id)
		{
			if (IsUserInList(id)) return;

			this.Users.Add(new ChatUser
			{
				Id = id
				// Username =
			});
			OnUserAdd?.Invoke();
		}
		public void RemoveUser(ChatUser user)
		{
			this.Users.Remove(user);
			OnUserRemove?.Invoke();
		}

		private bool IsUserInList(int id)
		{
			if (GetChatUserById(id) is not null) return true;
			return false;
		}
	}
}
