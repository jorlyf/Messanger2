using Microsoft.AspNetCore.Mvc;
using back.Models;
using back.Infrastructure;
using back.Services;

namespace back.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ChatController : ControllerBaseTokenRequired
	{
		private ChatService ChatService { get; }
		public ChatController(JWTService jwtService, ChatService chatService) : base(jwtService)
		{
			this.ChatService = chatService;
		}
		[HttpPost]
		[Route("SendMessage")]
		public IActionResult SendMessage([FromForm] ChatMessageSendingDto messsageDto)
		{
			if (!ValidateToken(out User user)) return Unauthorized();



			return Ok();
		}

		[HttpGet]
		[Route("GetChatDialogs")]
		public IActionResult GetChatDialogs()
		{
			if (!ValidateToken(out User user)) return Unauthorized();

			

			return Ok();
		}

		[HttpGet]
		[Route("GetMessages")]
		public IActionResult GetMessages()
		{
			if (!ValidateToken(out User user)) return Unauthorized();



			return Ok();
		}
	}
}
