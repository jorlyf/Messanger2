using Microsoft.AspNetCore.Mvc;
using back.Models;
using back.Infrastructure;
using back.Services;
using back.Models.Dtos;

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

			IEnumerable<ChatDialog> chatDialogs = this.ChatService.GetChatDialogs(user);

			IList<ChatDialogDto> dtos = new ChatDialogDto[chatDialogs.Count()];
			int i = 0;
			foreach (ChatDialog d in chatDialogs)
			{
				ChatDialogDto dto = new();
				dto.Id = d.Id;
				dto.Name = d.Name;
				dto.AvatarUrl = d.AvatarUrl;


				dto.UserIds = d.Users.Select(u => u.Id).ToArray();
				ChatMessageDto[] messageDtos = new ChatMessageDto[d.Messages.Length];
				int j = 0;
				foreach (ChatMessage cm in d.Messages)
				{
					ChatMessageDto cmDto = new ChatMessageDto();
					cmDto.Id = cm.Id;
					cmDto.ChatDialogId = cm.ChatDialogid;
					cmDto.UserSenderId = cm.Sender.Id;
					cmDto.Text = cm.Text;
					cmDto.Attachments = cm.Attachments;
					cmDto.SentAt = cm.SentAt;
					messageDtos[j++] = cmDto;
				}
				dtos[i++] = dto;
			}

			return Ok(dtos);
		}

		[HttpGet]
		[Route("GetMessages")]
		public IActionResult GetMessages()
		{
			if (!ValidateToken(out User user)) return Unauthorized();



			return Ok();
		}

		[HttpGet]
		[Route("GetUsersByLogin")]
		public IActionResult GetUsersByLogin(string login)
		{
			if (!ValidateToken(out User user)) return Unauthorized();
			if (string.IsNullOrEmpty(login)) return BadRequest();

			this.ChatService.GetUsersByContainsLogin(login);
			throw new NotImplementedException();
		}
	}
}
