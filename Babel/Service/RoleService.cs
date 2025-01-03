using Babel.Models;
using Babel.Repository.IRepository;
using Babel.Service.IService;

namespace Babel.Service
{
    public class RoleService : IRoleService
    {
  private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<List<Role>> GetRolesAsync()
    {
        return await _roleRepository.GetRolesAsync();
    }

    public async Task<Role> GetRoleAsync(int id)
    {
        return await _roleRepository.GetRoleAsync(id);
    }

    public async Task<Role> CreateRoleAsync(Role role)
    {
        return await _roleRepository.CreateRoleAsync(role);
    }

    public async Task<Role> UpdateRoleAsync(Role role)
    {
        var existingRole = await _roleRepository.GetRoleAsync(role.Id);
        if (existingRole == null)
        {
            throw new Exception($"Role with ID {role.Id} not found.");
        }
        return await _roleRepository.UpdateRoleAsync(role);
    }

    public async Task<bool> DeleteRoleAsync(int id)
    {
        var role = await _roleRepository.GetRoleAsync(id);
        if (role == null)
        {
            throw new Exception($"Role with ID {id} not found.");
        }
        await _roleRepository.DeleteRoleAsync(role);
        return true;
    }
}
}
