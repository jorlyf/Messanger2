﻿namespace back.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Login { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string AvatarUrl { get; set; }
	}
}
