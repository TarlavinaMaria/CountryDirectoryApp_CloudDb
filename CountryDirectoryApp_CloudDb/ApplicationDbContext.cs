using Microsoft.EntityFrameworkCore;

namespace CountryDirectoryApp_CloudDb
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
