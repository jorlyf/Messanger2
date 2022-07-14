using back.Models;
using back.Repositories;

namespace back.Services
{
	public class UserProfileService
	{
		private IRepository<User>? UserRepository { get; set; }

		public bool ChangeUsername(User user, string newUsername)
		{
			if (!ValidateUsernameLength(newUsername)) return false;

			try
			{
				using (this.UserRepository = new Repository<User>())
				{
					user.Username = newUsername;
					this.UserRepository.Update(user);
					this.UserRepository.Save();
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool ChangePassword(User user, string newPassword)
		{
			if (!ValidatePasswordLength(newPassword)) return false;

			try
			{
				using (this.UserRepository = new Repository<User>())
				{
					user.Password = newPassword;
					this.UserRepository.Update(user);
					this.UserRepository.Save();
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool ChangeAvatarUrl(User user, string newAvatarUrl)
		{
			try
			{
				using (this.UserRepository = new Repository<User>())
				{
					user.AvatarUrl = newAvatarUrl;
					this.UserRepository.Update(user);
					this.UserRepository.Save();
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool ChangeAvatar(User user, IFormFile file)
		{
			throw new NotImplementedException();
		}

		private bool ValidateUsernameLength(string username) => username.Length >= 2 && username.Length <= 24;
		private bool ValidatePasswordLength(string password) => password.Length >= 5 && password.Length <= 24;
	}
}
