namespace back.Models
{
	public class ChatMessage
	{
		public int Id { get; set; }
		public ChatUser Sender { get; set; }
		public string Text { get; set; }
		public ChatAttachment[] Attachments { get; set; }
	}
}
