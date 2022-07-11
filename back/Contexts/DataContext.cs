using back.Models;
using Microsoft.EntityFrameworkCore;

namespace back.Contexts
{
	public class DataContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<ChatDialog> ChatDialogs { get; set; }
		public DataContext()
		{
			this.Database.Migrate();
		}
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlite($"Data Source={Environment.CurrentDirectory}\\messanger.db");
		}
	}
}
