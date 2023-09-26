using datingAppBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace YourNamespace.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Check if the database already has data
            if (context.Users.Any())
            {
                return; // Database has been seeded
            }

            // Seed your data here
            var users = new User[]
            {
                new User { FirstName = "John", LastName = "Doe", Email = "john@example.com" },
                new User { FirstName = "Jane", LastName = "Smith", Email = "jane@example.com" },
                // Add more user data
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
