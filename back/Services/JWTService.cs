using JWT;
using JWT.exceptions;

using back.Models;
using back.Contexts;

namespace back.Services
{
	public class JWTService
	{
		private readonly string SECRET_KEY = "xyuxyuxyuxyuxyuxyuxyuxyu";
		private readonly long EXP_TIME = (long)TimeSpan.FromDays(30).TotalSeconds;
		public string GenerateToken(User user)
		{
			var payload = new Dictionary<string, object>()
			{
				{"id", user.Id},
				{"login", user.Login},
				{"exp", Utils.TotalSecondsNow}
			};
			return JsonWebToken.Encode(payload, this.SECRET_KEY, JwtHashAlgorithm.HS256);
		}
		public User? DecodeToken(string token)
		{
			try
			{
				var payload = JsonWebToken.DecodeToObject(token, this.SECRET_KEY) as IDictionary<string, object>;
				if (payload is null) return null;

				using (var dataContext = new DataContext())
				{
					if (payload.TryGetValue("id", out object? idObj))
					{
						int id = (int)idObj;
						return dataContext.Users.ToArray().FirstOrDefault(u => u.Id == id);
					}
					else return null;
				}
			}
			catch (SignatureVerificationException)
			{
				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}
		public bool ValidateToken(string token)
		{
			try
			{
				var payload = JsonWebToken.DecodeToObject(token, this.SECRET_KEY) as IDictionary<string, object>;
				if (payload is null) return false;

				if (payload.TryGetValue("exp", out object? exp))
				{
					if (Utils.TotalSecondsNow - (long)exp > this.EXP_TIME) return false;
				}
				else return false;

				return true;
			}
			catch (SignatureVerificationException)
			{
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
