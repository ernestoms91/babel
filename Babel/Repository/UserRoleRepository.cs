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
        UserRol IUserRolRepository.Create(UserRol userRol)
        {          
            _bd.UsersRoles.Add(userRol);
            _bd.SaveChanges();
            return userRol;
        }

        UserRol IUserRolRepository.Update(UserRol userRol)
        {
            _bd.UsersRoles.Update(userRol);
            _bd.SaveChanges();
            return userRol;
        }



    }
}
