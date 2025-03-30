using Microsoft.EntityFrameworkCore;
using System;

namespace Ecommerce.Services.UsersServices.Domain.Entities
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = default!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}