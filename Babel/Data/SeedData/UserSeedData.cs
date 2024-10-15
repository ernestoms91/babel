using Babel.Models;
using Microsoft.EntityFrameworkCore;

namespace Babel.Data.SeedData
{
    public class UserSeedData
    {
        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "John",
                    Lastname = "Doe",
                    UserName = "johndoe",
                    Email = "john.doe@example.com",
                    Nid = "123456789",
                    Phone = "123-456-7890",
                    Description = "Admin user",
                    Active = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 2,
                    Name = "Jane",
                    Lastname = "Smith",
                    UserName = "janesmith",
                    Email = "jane.smith@example.com",
                    Nid = "987654321",
                    Phone = "987-654-3210",
                    Description = "Manager",
                    Active = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 3,
                    Name = "Alice",
                    Lastname = "Johnson",
                    UserName = "alicej",
                    Email = "alice.johnson@example.com",
                    Nid = "123789456",
                    Phone = "456-123-7890",
                    Description = "HR",
                    Active = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 4,
                    Name = "Bob",
                    Lastname = "Williams",
                    UserName = "bobwilliams",
                    Email = "bob.williams@example.com",
                    Nid = "789456123",
                    Phone = "321-654-9870",
                    Description = "IT Support",
                    Active = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 5,
                    Name = "Charlie",
                    Lastname = "Brown",
                    UserName = "charliebrown",
                    Email = "charlie.brown@example.com",
                    Nid = "456789123",
                    Phone = "654-987-1230",
                    Description = "Sales",
                    Active = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }

    }
}
