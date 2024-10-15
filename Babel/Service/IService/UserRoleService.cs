using Babel.Models;
using Babel.Repository.IRepository;

namespace Babel.Service.IService
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserRolRepository _userRolRepository;

        public UserRoleService( IRoleRepository roleRepository , IUserRepository userRepository , IUserRolRepository userRolRepository) { 
            _roleRepository = roleRepository;
            _userRepository = userRepository;   
            _userRolRepository = userRolRepository;
        }

        UserRol IUserRoleService.Create(UserRol userRol)
        {
            throw new NotImplementedException();
        }

        UserRol IUserRoleService.Update(UserRol userRol)
        {
            throw new NotImplementedException();
        }
    }
}
