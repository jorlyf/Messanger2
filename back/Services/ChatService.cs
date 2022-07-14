using back.Models;
using back.Repositories;

namespace back.Services
{
	public class ChatService
	{
		private IRepository<ChatDialog>? DialogRepository { get; set; }
		private IRepository<User>? UserRepository { get; set; }

		public ChatDialog? GetChatDialog(int dialogId)
		{
			try
			{
				using (this.DialogRepository = new Repository<ChatDialog>())
				{
					return this.DialogRepository.Get(dialogId);
				}
			}
			catch (Exception ex)
			{
				LoggerService.ExceptionOccured(ex);
				return null;
			}
		}
		public IEnumerable<ChatMessage> GetMessages(int dialogId)
		{
			ChatDialog? dialog = GetChatDialog(dialogId);
			if (dialog is null) return Enumerable.Empty<ChatMessage>();

			try
			{
				using (this.DialogRepository = new Repository<ChatDialog>())
				{
					if (dialog.Messages is null) return Enumerable.Empty<ChatMessage>();

					return dialog.Messages.ToList();
				}
			}
			catch (Exception ex)
			{
				LoggerService.ExceptionOccured(ex);
				return Enumerable.Empty<ChatMessage>();
			}
		}
		public IEnumerable<ChatDialog> GetChatDialogs(User user)
		{
			try
			{
				using (this.DialogRepository = new Repository<ChatDialog>())
				{
					IEnumerable<ChatDialog> dialogs = this.DialogRepository.GetMany(x => x.Users.Contains(user));
					if (dialogs is null) return Enumerable.Empty<ChatDialog>();

					return dialogs;
				}
			}
			catch (Exception ex)
			{
				LoggerService.ExceptionOccured(ex);
				return Enumerable.Empty<ChatDialog>();
			}
		}
		public IEnumerable<User> GetUsersByContainsLogin(string login)
		{
			try
			{
				using (this.UserRepository = new Repository<User>())
				{
					return this.UserRepository.GetMany(x => x.Login.Contains(login));
				}

			}
			catch (Exception ex)
			{
				LoggerService.ExceptionOccured(ex);
				return Enumerable.Empty<User>();
			}
		}
	}
}
