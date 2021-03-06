namespace back.Models
{
	public class ChatDialog
	{
		public int Id { get; set; }

		public ChatMessage[]? Messages { get; set; }

		public User[]? Users { get; set; }

		public string? Name { get; set; }

		public string? AvatarUrl { get; set; }
	}
}
