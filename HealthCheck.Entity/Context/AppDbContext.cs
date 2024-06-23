using HealthCheck.Entity.Entities;
using HealthCheck.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCheck.Entity.Context
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}
