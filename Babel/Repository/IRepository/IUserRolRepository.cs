using Babel.Models;

namespace Babel.Repository.IRepository
{
    public interface IUserRolRepository
    {

        UserRol Create( UserRol userRol);
        UserRol Update(UserRol userRol);
        void SaveChanges();

    }
}
