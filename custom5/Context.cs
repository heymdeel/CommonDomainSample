using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace custom5
{
    class Context : DbContext
    {
        public DbSet<CustomUser> Users { get; set; }

        public DbSet<CustomRole> Roles { get; set; }

        public DbSet<CustomTest> Tests { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseNpgsql(@"Host=localhost;Port=5432;Database=test5;Username=postgres;Password=postgres");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
