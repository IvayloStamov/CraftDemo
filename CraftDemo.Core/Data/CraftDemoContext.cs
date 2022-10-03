using CraftDemo.Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CraftDemo.Core.Data
{
    public class CraftDemoContext : DbContext
    {
        public CraftDemoContext() {}
        public CraftDemoContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        public DbSet<GithubUser> GithubUsers { get; set; }
    }
}
