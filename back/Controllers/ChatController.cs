using Microsoft.AspNetCore.Mvc;
using back.Models;

namespace back.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ChatController : ControllerBase
	{
		[HttpPost]
		[Route("SendMessage")]
		public IActionResult SendMessage([FromForm] ChatMessage chatMessage)
		{
			return Ok();
		}
		[HttpGet]
		[Route("GetMessages")]
		public IActionResult GetMessages()
		{
			return Ok();
		}
		[HttpPost]
		[Route("GetChatOwner")]
		public IActionResult GetChatOwner()
		{

			return Ok();
		}
	}
}
