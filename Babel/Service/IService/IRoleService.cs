using Babel.Models;

namespace Babel.Service.IService
{
    public interface IRoleService
    {
        List<Role> GetRoles();       
        Role GetRole(int id); 
        Role CreateRole(Role role); 
        Role UpdateRole(Role role); 
        bool DeleteRole(int id);
    }
}
