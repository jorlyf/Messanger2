using back.Models;
using back.Models.Dtos;
using back.Repositories;

namespace back.Services
{
	public class AuthService
	{
		private IRepository<User>? UserRepository { get; set; }
		private JWTService JWTService { get; }

		public AuthService(JWTService jwtService)
		{
			this.JWTService = jwtService;
		}

		public User? LoginByToken(string token)
		{
			User? user = this.JWTService.DecodeToken(token);
			return user;
		}
		public User? Login(UserLoginDataDto userLoginData)
		{
			try
			{
				using (this.UserRepository = new Repository<User>())
				{
					User? user = this.UserRepository.Get(x => x.Login == userLoginData.Login);
					if (user?.Password == userLoginData.Password) return user;

					return null;
				}
			}
			catch (Exception ex)
			{
				LoggerService.ExceptionOccured(ex);
				return null;
			}
		}
		public User? Registrate(UserLoginDataDto userReg)
		{
			try
			{
				using (this.UserRepository = new Repository<User>())
				{
					if (!ValidateRegistration(userReg)) return null;
					User user = GetUser(userReg);
					this.UserRepository.Add(user);
					this.UserRepository.Save();
					return user;
				}
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
			User? user = this.UserRepository!.Get(x => x.Login == userReg.Login);
			if (user is not null) return false;

			return true;
		}
		private static User GetUser(UserLoginDataDto userReg)
		{
			return new User { Login = userReg.Login, Password = userReg.Password };
		}
	}
}
