using Babel.Models;

namespace Babel.Repository.IRepository
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetRolesAsync();
        Task<List<Role>> GetRolesByIdsAsync(int[] roleIds);
        Task<Role> GetRoleAsync(int id);
        Task<Role> CreateRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(Role role);
    }
}
