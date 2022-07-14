namespace back.Models.Dtos
{ 
	public class ChatMessageSendingDto
	{
		public int ChatDialogId { get; set; }

		public string? Text { get; set; }

		public ChatAttachment[]? Attachments { get; set; }
	}
}
