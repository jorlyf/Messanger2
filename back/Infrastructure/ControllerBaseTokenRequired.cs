using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc;
using back.Models;
using back.Services;

namespace back.Infrastructure
{
	public class ControllerBaseTokenRequired : ControllerBase
	{
		private JWTService JWTService { get; set; }

		public ControllerBaseTokenRequired(JWTService jwtService)
		{
			this.JWTService = jwtService;
		}

		protected virtual bool ValidateToken(out User user)
		{
			user = null;
			try
			{
				if (!this.Request.Headers.TryGetValue("Token", out StringValues token))
					return false;

				user = this.JWTService.DecodeToken(token);
				return true;
			}
			catch (Exception ex)
			{
				LoggerService.ExceptionOccured(ex);
				return false;
			}
		}
	}
}
