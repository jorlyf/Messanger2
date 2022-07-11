using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using back.Services;
using back.Models;

namespace back.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserProfileController : ControllerBase
	{
		private JWTService JWTService { get; }
		public UserProfileController(JWTService jwtService)
		{
			this.JWTService = jwtService;
		}

		[HttpPost]
		[Route("SetUsername")]
		public IActionResult SetUsername([FromBody] string newUsername)
		{
			if (!ValidateToken(out User? user)) return Unauthorized();

			Console.WriteLine($"Получен username = {newUsername}");

			return Ok();
		}

		private bool ValidateToken(out User? user)
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
