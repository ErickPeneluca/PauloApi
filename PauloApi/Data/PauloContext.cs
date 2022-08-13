using Microsoft.EntityFrameworkCore;
using PauloApi.Models;

namespace PauloApi.Data
{
    public class PauloContext : DbContext
    {
        public PauloContext(DbContextOptions<PauloContext> options) : base(options) { }

        public DbSet<Item> items { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();
            user.HasNoKey();
        }
    }
}
