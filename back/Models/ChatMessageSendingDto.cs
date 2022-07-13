namespace back.Models
{
	public class ChatMessageSendingDto
	{
		public int ChatDialogId { get; set; }

		public string? Text { get; set; }

		public ChatAttachment[]? Attachments { get; set; }
	}
}
