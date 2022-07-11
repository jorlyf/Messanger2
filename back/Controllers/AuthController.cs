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
			User? user = this.AuthService.LoginByToken(token).Result;
			if (user is null) return Unauthorized();


			UserLoginSuccessDataDto userLoginSuccessData = new()
			{
				Id = user.Id,
				Login = user.Login,
				Token = token
			};

			LoggerService.UserLoggedIn(user);
			return Ok(userLoginSuccessData);
		}
		[HttpPost]
		[Route("Login")]
		public IActionResult Login([FromBody] UserLoginDataDto userLoginData)
		{
			User? user = this.AuthService.Login(userLoginData).Result;
			if (user is null) return BadRequest();

			string token = this.JWTService.GenerateToken(user);
			UserLoginSuccessDataDto userLoginSuccessData = new()
			{
				Id = user.Id,
				Login = userLoginData.Login,
				Token = token
			};

			LoggerService.UserLoggedIn(user);
			return Ok(userLoginSuccessData);
		}

		[HttpPost]
		[Route("Registrate")]
		public IActionResult Registrate([FromBody] UserLoginDataDto userLoginData)
		{
			User? user = this.AuthService.Registrate(userLoginData).Result;
			if (user is null) return BadRequest();

			string token = this.JWTService.GenerateToken(user);
			UserLoginSuccessDataDto userLoginSuccessData = new()
			{
				Id = user.Id,
				Login = userLoginData.Login,
				Token = token
			};

			LoggerService.UserLoggedIn(user);
			return Ok(userLoginSuccessData);
		}
	}
}
