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

        User IUserRepository.CreateUser(User user)
        {
            _bd.Users.Add(user);

            _bd.SaveChanges();

            // Recarga el objeto para asegurarte de que tenga todos los valores de la base de datos
            _bd.Entry(user).Reload();

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
            .Include(u => u.UserRoles) // Si necesitas incluir roles
            .FirstOrDefault(u => u.Id == id);
        }

        List<User> IUserRepository.GetUsers()
        {
            return _bd.Users
            .Include(u => u.UserRoles) // Si necesitas incluir roles
            .ToList();
        }

        User IUserRepository.UpdateUser(User user)
        {
            var existingUser = _bd.Users.Find(user.Id);
            if (existingUser == null)
            {
                throw new ArgumentException("Usuario no encontrado.");
            }

            // Actualiza las propiedades
            existingUser.Name = user.Name;
            existingUser.Lastname = user.Lastname;
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.Phone = user.Phone;
            existingUser.Description = user.Description;
            existingUser.active = user.active;
            existingUser.UpdatedAt = DateTime.Now;

            _bd.Users.Update(existingUser);
            _bd.SaveChanges(); // Guarda los cambios en la base de datos

            return existingUser; // Retorna el usuario actualizado
        }
    }
}