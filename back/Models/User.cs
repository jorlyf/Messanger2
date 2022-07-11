using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace back.Models
{
	[Index(nameof(Login), IsUnique = true)]
	public class User
	{
		public int Id { get; set; }

		[Required]
		public string Login { get; set; }

		[Required]
		public string Password { get; set; }

		public string? Username { get; set; }

		public string? AvatarUrl { get; set; }
	}
}
