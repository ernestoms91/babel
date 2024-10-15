using Babel.Models;
using Babel.Repository.IRepository;
using Babel.Service.IService;

namespace Babel.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(User user)
        {
         return _userRepository.CreateUser(user);

        }

        public bool ChangeUserStatus(int id)
        {
            var user = _userRepository.GetUser(id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            user.Active = !user.Active;
            _userRepository.UpdateUser(user);
            return user.Active;
        }

        public User UpdateUser(int id)
        {
            throw new NotImplementedException();
        }

        User IUserService.GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            return user;
        }


        List<User> IUserService.GetUsers()
        {
            return _userRepository.GetUsers();
        }

    }
}
