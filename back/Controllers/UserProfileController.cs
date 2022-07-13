using Microsoft.AspNetCore.Mvc;
using back.Services;
using back.Models;
using back.Infrastructure;

namespace back.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserProfileController : ControllerBaseTokenRequired
	{
		private UserProfileService UserProfileService { get; }
		public UserProfileController(JWTService jwtService, UserProfileService userProfileService) : base(jwtService)
		{
			this.UserProfileService = userProfileService;
		}

		[HttpPost]
		[Route("SetUsername")]
		public IActionResult SetUsername([FromBody] IDictionary<string, string> newUsernameJson)
		{
			string newUsername = newUsernameJson.Values.First();
			if (!ValidateToken(out User user)) return Unauthorized();

			if (this.UserProfileService.ChangeUsername(user.Id, newUsername).Result)
			{
				return Ok(newUsername);
			}
			return BadRequest();
		}
	}
}
