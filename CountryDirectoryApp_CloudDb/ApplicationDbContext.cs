using Microsoft.EntityFrameworkCore;

namespace CountryDirectoryApp_CloudDb
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"
            User Id=postgres.epqmsmbycdvufduhqvfc;
            Password=Taralvina592780s;
            Server=aws-0-us-east-1.pooler.supabase.com;
            Port=5432;
            Database=postgres;
            ";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
