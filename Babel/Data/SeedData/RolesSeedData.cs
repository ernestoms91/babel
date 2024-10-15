using Babel.Models;
using Microsoft.EntityFrameworkCore;

namespace Babel.Data.SeedData
{
    public static class RolesSeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Secretaria" },
                new Role { Id = 2, RoleName = "Administrador" },
                new Role { Id = 3, RoleName = "Estudiante" }
            );
        }
    }
}
