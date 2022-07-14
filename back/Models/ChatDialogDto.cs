namespace back.Models
{
	public class ChatDialogDto
	{
		public int Id { get; set; }

		public ChatMessage[]? Messages { get; set; }

		public int[]? UserIds { get; set; }

		public string? Name { get; set; }

		public string? AvatarUrl { get; set; }
	}
}
