using Microsoft.EntityFrameworkCore;

namespace NewsAppAngular2x.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Krävs, annars blir det runtimefel vid Startup.cs (AddDbContext)
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
