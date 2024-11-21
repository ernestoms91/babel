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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper, IRoleRepository roleRepository,
            IUserRolRepository userRolRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRolRepository = userRolRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<Result<UserDto>> CreateUserAsync(NewUserDto newUserDto)
        {
            var role = _roleRepository.GetRole(newUserDto.Role);

            if (role == null)
            {
                return Result<UserDto>.Failure(RoleErrors.RoleNotFound(newUserDto.Role));
            }

            if (_userRepository.PhoneNumberExits(newUserDto.Phone) != null)
            {
                return Result<UserDto>.Failure(UserErrors.PhoneNumberAlreadyExists);
            }

            // Validar que el NID no existe
            if (_userRepository.NidExits(newUserDto.Nid) != null)
            {
                return Result<UserDto>.Failure(UserErrors.NidAlreadyExists);
            }

            // Validar que el correo electrónico no existe
            if (_userRepository.EmailExits(newUserDto.Email) != null)
            {
                return Result<UserDto>.Failure(UserErrors.EmailAlreadyExists);
            }


            var user = _mapper.Map<User>(newUserDto);
            _unitOfWork.UserRepository.CreateUser(user);

            // Crear la relación de usuario y rol
            var userRole = new UserRol
            {
                User = user,
                RoleId = role.Id
            };

            _unitOfWork.UserRolRepository.Create(userRole);
            await _unitOfWork.Save();

            var userDto = _mapper.Map<UserDto>(user);
            // Confirmar la transacción

            return Result<UserDto>.Success(userDto);

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
