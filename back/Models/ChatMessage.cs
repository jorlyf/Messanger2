using System.ComponentModel.DataAnnotations;

namespace back.Models
{
	public class ChatMessage
	{
		public int Id { get; set; }

		[Required]
		public User Sender { get; set; }

		public string? Text { get; set; }

		public ChatAttachment[]? Attachments { get; set; }

		public DateTime SentAt { get; set; }
	}
}
