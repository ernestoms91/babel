using AutoMapper;
using Babel.Errors;
using Babel.Models;
using Babel.Models.Dtos;
using Babel.Repository.IRepository;
using Babel.Service.IService;

namespace Babel.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public User CreateUser(User user)
        {
         return _userRepository.CreateUser(user);

        }

        public Result<UserDto> ChangeUserStatus(int id)
        {
            var user = _userRepository.GetUser(id);
            if (user == null)
            {
                return Result<UserDto>.Failure(UserErrors.UserNotFound(id));
            }
            user.Active = !user.Active;
            _userRepository.UpdateUser(user);

            var userDto = _mapper.Map<UserDto>(user);

            return Result<UserDto>.Success(userDto);
        }

         User IUserService.UpdateUser(int id)
        {
            throw new NotImplementedException();
        }

         public Result<UserDto> GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            if (user == null)
            {
                return Result<UserDto>.Failure(UserErrors.UserNotFound(id));
            }

            var userDto = _mapper.Map<UserDto>(user);

            return Result<UserDto>.Success(userDto);
        }


         public Result<List<UserDto>> GetUsers()
        {
            var users = _userRepository.GetUsers();

            if (users == null || !users.Any())
            {
                return Result<List<UserDto>>.Failure(UserErrors.NoUsersFound);
            }
            var userDtos = _mapper.Map<List<UserDto>>(users);
            return Result<List<UserDto>>.Success(userDtos);
        }

    }
}
