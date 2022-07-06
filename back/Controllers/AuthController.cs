using Microsoft.AspNetCore.Mvc;

using back.Models;
using back.Services;

namespace back.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private AuthService AuthService { get; }

		public AuthController(AuthService authService)
		{
			this.AuthService = authService;
		}

		[HttpPost]
		[Route("Registrate")]
		public IActionResult Registrate([FromForm] UserRegistrationDto userReg)
		{
			User? user = this.AuthService.Registrate(userReg).Result;
			if (user is null) return BadRequest();

			Console.WriteLine($"{user.Login} was registrated");

			return Ok();
		}
	}
}
