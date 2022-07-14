namespace back.Models.Dtos
{
	public class ChatMessageDto
	{
		public int Id { get; set; }

		public int ChatDialogId { get; set; }

		public int UserSenderId { get; set; }

		public string? Text { get; set; }

		public ChatAttachment[]? Attachments { get; set; }

		public DateTime SentAt { get; set; }
	}
}
