using Babel.Models;
using Microsoft.EntityFrameworkCore;

namespace Babel.Data.SeedData
{
    public  static class UserRoleSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRol>().HasData(
              new UserRol { UsuarioId = 1, RoleId = 2 }, 
              new UserRol { UsuarioId = 2, RoleId = 1 }, 
              new UserRol { UsuarioId = 3, RoleId = 3 },
              new UserRol { UsuarioId = 4, RoleId = 3 },
              new UserRol { UsuarioId = 5, RoleId = 3 }
            );
        }
    }
}
