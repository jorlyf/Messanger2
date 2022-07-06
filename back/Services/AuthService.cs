using back.Contexts;
using back.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace back.Services
{
	public class AuthService
	{
		private DataContext? DataContext { get; set; }

		public async Task<User?> Registrate(UserRegistrationDto userReg)
		{
			try
			{
				this.DataContext = new DataContext();
				if (!ValidateRegistration(userReg)) return null;

				EntityEntry<User> userEntity = await this.DataContext.Users.AddAsync(new User
				{
					Login = userReg.Login,
					Username = userReg.Username,
					Password = userReg.Password
				});

				this.DataContext.SaveChanges();
				this.DataContext.Dispose();
				return userEntity.Entity;
			}
			catch (Exception)
			{
				Console.WriteLine("Ошибка в AuthService.Registrate()");
				return null;
			}
		}
		private bool ValidateRegistration(UserRegistrationDto userReg)
		{
			// validate login
			if (this.DataContext!.Users.ToArray().FirstOrDefault(u => u.Login.Trim() == userReg.Login.Trim()) is not null)
				return false;

			return true;
		}
	}
}
