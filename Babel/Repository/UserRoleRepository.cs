using Babel.Data;
using Babel.Models;
using Babel.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Babel.Repository
{
    public class UserRoleRepository : IUserRolRepository
    {
        private readonly ApplicationDbContext _bd;
        public UserRoleRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public async Task CreateAsync(User user, List<UserRol> userRoles)
        {
            await _bd.Users.AddAsync(user); // Agrega el usuario de manera asincrónica
            await _bd.UsersRoles.AddRangeAsync(userRoles); // Agrega el objeto UserRol de manera asincrónica
            await _bd.SaveChangesAsync(); // Guarda los cambios de manera asincrónica
        }

        public async Task UpdateAsync(User user, List<UserRol> userRoles)
        {
            _bd.Users.Update(user);
            await _bd.UsersRoles.AddRangeAsync(userRoles);
            await _bd.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _bd.SaveChangesAsync(); // Guarda los cambios de manera asincrónica
        }

        public async Task RemoveByUserIdAsync(int id)
        {
            var userRoles = await _bd.UsersRoles
         .Where(ur => ur.UsuarioId == id)
         .ToListAsync();

            _bd.UsersRoles.RemoveRange(userRoles);
            await _bd.SaveChangesAsync();
        }
    }
}
