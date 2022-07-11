namespace back.Models
{
	public class ChatAttachment
	{
		public int Id { get; set; }

		public ChatAttachmentTypes Type { get; set; }

		public string Url { get; set; }
	}

	public enum ChatAttachmentTypes : byte
	{
		photo,
		video,
		audio
	}
}
