using back.Models;
using Microsoft.EntityFrameworkCore;

namespace back.Contexts
{
	public class DataContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<ChatMessage> ChatMessages { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			Console.WriteLine($"Data Source={Environment.CurrentDirectory}\\messanger.db");
			options.UseSqlite($"Data Source={Environment.CurrentDirectory}\\messanger.db");
		}
	}
}
