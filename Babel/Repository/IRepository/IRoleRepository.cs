using Babel.Models;

namespace Babel.Repository.IRepository
{
    public interface IRoleRepository
    {
            List<Role> GetRoles();
            Role GetRole(int id);
            Role CreateRole(Role role); 
            Role UpdateRole(Role role);  
            void DeleteRole(Role role);  
    }
}
