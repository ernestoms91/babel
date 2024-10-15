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

        public List<Role> GetRoles()
        {
            return _roleRepository.GetRoles();
        }

        public Role GetRole(int id)
        {
            var role = _roleRepository.GetRole(id);
            if (role == null)
            {
                throw new Exception($"Role with ID {id} not found.");
            }
            return role;
        }

        public Role CreateRole(Role role)
        {
            return _roleRepository.CreateRole(role);
        }

        public Role UpdateRole(Role role)
        {
            var existingRole = _roleRepository.GetRole(role.Id);
            if (existingRole == null)
            {
                throw new Exception($"Role with ID {role.Id} not found.");
            }
            return _roleRepository.UpdateRole(role);
        }

        public bool DeleteRole(int id)
        {
            var role = _roleRepository.GetRole(id);
            if (role == null)
            {
                throw new Exception($"Role with ID {id} not found.");
            }
            _roleRepository.DeleteRole(role);
            return true;
        }
    }
}
