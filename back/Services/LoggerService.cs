using back.Models;

namespace back.Services
{
	public static class LoggerService
	{
		#region User
		public static void UserConnected(ChatUser user)
		{
			Write($"User {user.Username} was connected.");
		}
		public static void UserDisconnected(ChatUser user)
		{
			Write($"User {user.Username} was disconnected.");
		}

		public static void UserLoggedIn(User user)
		{
			Write($"User {user.Login} was logged-in.");
		}
		public static void UserSentMessage(User user, string messageText)
		{
			Write($"User {user.Login} sent message: {messageText}");
		}
		#endregion

		public static void ExceptionOccured(Exception ex)
		{
			Write($"Exception: {ex.Message} in {ex.Source}");
		}

		public static void Write(string message)
		{
			Console.WriteLine($"[Log] {DateTime.UtcNow.ToLocalTime().ToShortTimeString()}: {message}");
		}
	}
}
