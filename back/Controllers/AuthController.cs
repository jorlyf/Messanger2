using Microsoft.AspNetCore.Mvc;

using back.Models;
using back.Services;
using back.Models.Dtos;

namespace back.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private AuthService AuthService { get; }
		private JWTService JWTService { get; }

		public AuthController(AuthService authService, JWTService jwtService)
		{
			this.AuthService = authService;
			this.JWTService = jwtService;
		}

		[HttpPost]
		[Route("LoginByToken")]
		public IActionResult LoginByToken([FromHeader] string token)
		{
			User? user = this.AuthService.LoginByToken(token);
			if (user is null) return Unauthorized();

			LoggerService.UserLoggedIn(user);
			return Ok(GetUserLoginSuccessDataDto(user, token));
		}

		[HttpPost]
		[Route("Login")]
		public IActionResult Login([FromBody] UserLoginDataDto userLoginData)
		{
			User? user = this.AuthService.Login(userLoginData);
			if (user is null) return BadRequest();

			string token = this.JWTService.GenerateToken(user);

			LoggerService.UserLoggedIn(user);
			return Ok(GetUserLoginSuccessDataDto(user, token));
		}

		[HttpPost]
		[Route("Registrate")]
		public IActionResult Registrate([FromBody] UserLoginDataDto userLoginData)
		{
			User? user = this.AuthService.Registrate(userLoginData);
			if (user is null) return BadRequest();

			string token = this.JWTService.GenerateToken(user);

			LoggerService.UserLoggedIn(user);
			return Ok(GetUserLoginSuccessDataDto(user, token));
		}

		private UserLoginSuccessDataDto GetUserLoginSuccessDataDto(User? user, string token) =>
			new UserLoginSuccessDataDto
			{
				Id = user.Id,
				Login = user.Login,
				Username = user.Username,
				AvatarUrl = user.AvatarUrl,
				Token = token
			};
	}
}
