using Babel.Models;

namespace Babel.Service.IService
{
    public interface IUserRoleService
    {
        UserRol Create(UserRol userRol);
        UserRol Update(UserRol userRol);
    }
}
