using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
	public class DataBaseContext : DbContext
	{
        public DbSet<User> Users { get; set; }
		public DbSet<Language> Languages { get; set; }
		public DbSet<Connection> Connections { get; set; }
		public DataBaseContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
