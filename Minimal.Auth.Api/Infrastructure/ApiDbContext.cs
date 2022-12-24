using Microsoft.EntityFrameworkCore;
using Minimal.Auth.Api.Domain.Customer.Entities;

namespace Minimal.Auth.Api.Infrastructure
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
