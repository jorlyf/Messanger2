namespace back.Models
{
	public class UserLoginSuccessDataDto
	{
		public int Id { get; set; }

		public string Login { get; set; }

		public string Username { get; set; }

		public string AvatarUrl { get; set; }

		public string Token { get; set; }

	}
}
