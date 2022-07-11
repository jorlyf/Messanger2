using back.Contexts;
using back.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace back.Services
{
	public class AuthService
	{
		private DataContext? DataContext { get; set; }
		private JWTService JWTService { get; }
		public AuthService(JWTService jwtService)
		{
			this.JWTService = jwtService;
		}
		public async Task<User?> LoginByToken(string token)
		{
			User? user = this.JWTService.DecodeToken(token);
			if (user is null) return null;

			return user;
		}
		public async Task<User?> Login(UserLoginDataDto userLoginData)
		{
			try
			{
				User? user;
				using (this.DataContext = new DataContext())
				{
					user = this.DataContext.Users.ToArray().FirstOrDefault(u => u.Login == userLoginData.Login);
				}
				if (user is null) return null;

				if (user.Password == userLoginData.Password) return user;
				else return null;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Ошибка в AuthService.Login()");
				Console.WriteLine(ex.Message);
				return null;
			}
		}
		public async Task<User?> Registrate(UserLoginDataDto userReg)
		{
			try
			{
				EntityEntry<User> userEntity;
				using (this.DataContext = new DataContext())
				{
					if (!ValidateRegistration(userReg)) return null;
					userEntity = await this.DataContext.Users.AddAsync(new User
					{
						Login = userReg.Login,
						Password = userReg.Password
					});
					await this.DataContext.SaveChangesAsync();
				}
				return userEntity.Entity;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Ошибка в AuthService.Registrate()");
				Console.WriteLine(ex.Message);
				return null;
			}
		}

		private bool ValidateRegistration(UserLoginDataDto userReg)
		{
			// validate login
			if (this.DataContext!.Users.ToArray().FirstOrDefault(u => u.Login.Trim() == userReg.Login.Trim()) is not null)
				return false;

			return true;
		}
	}
}
