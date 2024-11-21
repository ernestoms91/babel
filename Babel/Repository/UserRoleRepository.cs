using Babel.Data;
using Babel.Models;
using Babel.Repository.IRepository;

namespace Babel.Repository
{
    public class UserRoleRepository : IUserRolRepository
    {

        private readonly ApplicationDbContext _bd;

        public UserRoleRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
        public UserRol Create(UserRol userRol)
        {
            _bd.UsersRoles.Add(userRol); // Agrega el objeto a la base de datos
            return userRol;
        }

        public UserRol Update(UserRol userRol)
        {
            _bd.UsersRoles.Update(userRol);
            _bd.SaveChanges();
            return userRol;
        }

        public void SaveChanges() // Método para guardar cambios
        {
            _bd.SaveChanges();
        }



    }
}
