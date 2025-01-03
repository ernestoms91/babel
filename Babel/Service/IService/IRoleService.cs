using Babel.Models;

namespace Babel.Service.IService
{
    public interface IRoleService
    {
        Task<List<Role>> GetRolesAsync();    
        Task<Role> GetRoleAsync(int id); 
        Task<Role> CreateRoleAsync(Role role); 
        Task<Role> UpdateRoleAsync(Role role); 
        Task<bool> DeleteRoleAsync(int id);           
    }
}
