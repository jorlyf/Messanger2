using back.Contexts;
using back.Models;

namespace back.Services
{
	public class UserProfileService
	{
		private DataContext? DataContext { get; set; }

		public async Task<bool> ChangeUsername(int userId, string newUsername)
		{
			if (!ValidateUsernameLength(newUsername)) return false;

			User? user;
			try
			{
				using (this.DataContext = new DataContext())
				{
					user = this.DataContext.Users.ToArray().FirstOrDefault(u => u.Id == userId);
					if (user is null) return false;

					user.Username = newUsername;
					await this.DataContext.SaveChangesAsync();
				}
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}
		public async Task<bool> ChangePassword(int userId, string newPassword)
		{
			if (!ValidatePasswordLength(newPassword)) return false;

			User? user;
			try
			{
				using (this.DataContext = new DataContext())
				{
					user = this.DataContext.Users.ToArray().FirstOrDefault(u => u.Id == userId);
					if (user is null) return false;

					user.Password = newPassword;
					await this.DataContext.SaveChangesAsync();
				}
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}
		public async Task<bool> ChangeAvatarUrl(int userId, string newAvatarUrl)
		{
			User? user;
			try
			{
				using (this.DataContext = new DataContext())
				{
					user = this.DataContext.Users.ToArray().FirstOrDefault(u => u.Id == userId);
					if (user is null) return false;

					user.AvatarUrl = newAvatarUrl;
					await this.DataContext.SaveChangesAsync();
				}
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}
		public async Task<bool> UploadAvatar(IFormFile file)
		{
			return true;
		}

		private bool ValidateUsernameLength(string username) => username.Length >= 2 && username.Length <= 24;
		private bool ValidatePasswordLength(string password) => password.Length >= 5 && password.Length <= 24;
	}
}
