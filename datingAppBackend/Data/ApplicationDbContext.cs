using datingAppBackend.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace YourNamespace.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define DbSet properties for your application's entities
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Message> Messages { get; set; }
        // Add more DbSet properties for other entities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships, constraints, and indexes
            // Example: modelBuilder.Entity<User>().HasMany(u => u.Messages).WithOne(m => m.User);
        }
    }
}
