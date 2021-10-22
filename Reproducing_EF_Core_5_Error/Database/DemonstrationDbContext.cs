using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Reproducing_EF_Core_5_Error.Database
{
    public class DemonstrationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = "localhost",
                Port = 5432,
                Database = "demonstration_db",
                Username = "postgres",
                Password = "postgres"
            };
            
            optionsBuilder
                .UseNpgsql(connectionStringBuilder.ConnectionString)
                .UseSnakeCaseNamingConvention();
        }
    }
}