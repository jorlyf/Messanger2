using JWT;
using back.Models;
using back.Repositories;

namespace back.Services
{
	public class JWTService
	{
		private IRepository<User>? UserRepository { get; set; }

		private readonly string SECRET_KEY = "&~n7m$^-+O(zvKaG|O~!*~jh#0pIlv})9YSJ#nkfQf+{Us0A]lCah;:E9Wz89u&";
		private readonly double EXP_TIME = TimeSpan.FromDays(30).TotalSeconds;

		public string GenerateToken(User user)
		{
			DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			double now = Math.Round((DateTime.UtcNow - unixEpoch).TotalSeconds);
			var payload = new Dictionary<string, object>()
			{
				{"id", user.Id},
				{"login", user.Login},
				{"exp", now + this.EXP_TIME}
			};
			return JsonWebToken.Encode(payload, this.SECRET_KEY, JwtHashAlgorithm.HS256);
		}
		public User? DecodeToken(string token)
		{
			if (string.IsNullOrEmpty(token)) return null;
			try
			{
				var payload = JsonWebToken.DecodeToObject(token, this.SECRET_KEY) as IDictionary<string, object>;
				if (payload is null) return null;

				using (this.UserRepository = new Repository<User>())
				{
					if (payload.TryGetValue("id", out object? idObj))
					{
						int id = (int)(long)idObj;
						return UserRepository.Get(id);
					}
					return null;
				}
			}
			catch (Exception ex)
			{
				LoggerService.ExceptionOccured(ex);
				return null;
			}
		}
	}
}
