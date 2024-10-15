using Babel.Data;
using Babel.Models;
using Babel.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Babel.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _bd;

        public UserRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public User CreateUser(User user)
        {
            _bd.Users.Add(user);
            _bd.SaveChanges();
            return user;
        }

        void IUserRepository.DeleteUser(User user)
        {
            _bd.Remove(user);
            _bd.SaveChanges();

        }

        User IUserRepository.GetUser(int id)
        {
            return _bd.Users
             .Include(u => u.UserRoles) // Incluye la colección de UserRoles
            .ThenInclude(ur => ur.Role) // Luego incluye la entidad Role asociada a UserRol
        .FirstOrDefault(u => u.Id == id); // Busca el usuario por ID
        }

        public List<User> GetUsers()
        {
            return _bd.Users
                .Include(u => u.UserRoles) // Incluye la relación UserRoles
                    .ThenInclude(ur => ur.Role) // Incluye la relación Role a través de UserRoles
                .OrderBy(u => u.UserName) // Ordena los usuarios por UserName
                .ToList(); // Convierte a lista
        }

        public void UpdateUser(User user)
        {
           _bd.Users.Entry(user).CurrentValues.SetValues(user);
            _bd.SaveChanges ();
        }
    }
}