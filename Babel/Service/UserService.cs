using AutoMapper;
using Babel.Data;
using Babel.Errors;
using Babel.Models;
using Babel.Models.Dtos;
using Babel.Repository;
using Babel.Repository.IRepository;
using Babel.Service.IService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Babel.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRolRepository _userRolRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper, IRoleRepository roleRepository,
            IUserRolRepository userRolRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRolRepository = userRolRepository;
            _mapper = mapper;
        }


        public async Task<Result<UserDto>> ChangeUserStatusAsync(int id) // Cambiado a asincrónico
        {
            var user = await _userRepository.GetUserAsync(id); // Cambiado a asincrónico
            if (user == null)
            {
                return Result<UserDto>.Failure(UserErrors.UserNotFound(id));
            }

            user.Active = !user.Active;
            await _userRepository.UpdateUserAsync(user); // Cambiado a asincrónico

            var userDto = _mapper.Map<UserDto>(user);

            return Result<UserDto>.Success(userDto);
        }

        public async Task<Result<UserDto>> GetUserAsync(int id) // Cambiado a asincrónico
        {
            var user = await _userRepository.GetUserAsync(id); // Cambiado a asincrónico
            if (user == null)
            {
                return Result<UserDto>.Failure(UserErrors.UserNotFound(id));
            }

            var userDto = _mapper.Map<UserDto>(user);

            return Result<UserDto>.Success(userDto);
        }

        public async Task<Result<List<UserDto>>> GetUsersAsync() // Cambiado a asincrónico
        {
            var users = await _userRepository.GetUsersAsync(); // Cambiado a asincrónico

            if (users == null || !users.Any())
            {
                return Result<List<UserDto>>.Failure(UserErrors.NoUsersFound);
            }
            var userDtos = _mapper.Map<List<UserDto>>(users);
            return Result<List<UserDto>>.Success(userDtos);
        }

        Task<Result<User>> IUserService.UpdateUserAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

}
