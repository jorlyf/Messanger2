using back.Contexts;
using back.Models;

namespace back.Services
{
	public class ChatService
	{
		private DataContext? DataContext { get; set; }
		public ICollection<ChatMessage>? GetMessages(int dialogId)
		{
			ChatDialog? dialog = GetChatDialog(dialogId);
			if (dialog is null) return null;

			try
			{
				using (this.DataContext = new DataContext())
				{
					return dialog.Messages?.ToArray();
				}
			}
			catch (Exception ex)
			{
				LoggerService.ExceptionOccured(ex);
				return null;
			}
		}
		public ChatDialog? GetChatDialog(int dialogId)
		{
			try
			{
				using (this.DataContext = new DataContext())
				{
					return this.DataContext.ChatDialogs.Where(d => d.Id == dialogId).FirstOrDefault();
				}
			}
			catch (Exception ex)
			{
				LoggerService.ExceptionOccured(ex);
				return null;
			}
		}
		public ChatDialog[] GetChatDialogs(User user)
		{
			try
			{
				using (this.DataContext = new DataContext())
				{
					return this.DataContext.ChatDialogs.Where(d => d.Users.Contains(user)).ToArray();
				}
			}
			catch (Exception ex)
			{
				LoggerService.ExceptionOccured(ex);
				return new ChatDialog[0];
			}
		}

		public User[] GetUsersByLogin(string login)
		{
			try
			{
				using (this.DataContext = new DataContext())
				{
					return this.DataContext.Users.Where(d => d.Login.Contains(login)).ToArray();
				}
			}
			catch (Exception ex)
			{
				LoggerService.ExceptionOccured(ex);
				return new User[0];
			}
		}
	}
}
