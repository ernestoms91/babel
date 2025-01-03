using AutoMapper;
using Babel.Errors;
using Babel.Models;
using Babel.Models.Dtos;
using Babel.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Babel.Service.IService
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserRolRepository _userRolRepository;
        private readonly IMapper _mapper;

        public UserRoleService(IRoleRepository roleRepository, IUserRepository userRepository, IUserRolRepository userRolRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _userRolRepository = userRolRepository;
            _mapper = mapper;
        }


        public async Task<Result<UserDto>> CreateAsync(NewUserDto newUserDto)
        {
            // Validar que todos los roles proporcionados existan
            var validRoles = await _roleRepository.GetRolesByIdsAsync(newUserDto.Roles);

            if (validRoles.Count != newUserDto.Roles.Length)
            {
                return Result<UserDto>.Failure(UserRoleErrors.InvalidRoleData);
            }

            if (await _userRepository.PhoneNumberExitsAsync(newUserDto.Phone) != null)
            {
                return Result<UserDto>.Failure(UserErrors.PhoneNumberAlreadyExists);
            }

            // Validar que el NID no existe
            if (await _userRepository.NidExitsAsync(newUserDto.Nid) != null)
            {

                return Result<UserDto>.Failure(UserErrors.NidAlreadyExists);
            }

            // Validar que el correo electrónico no existe
            if (await _userRepository.EmailExitsAsync(newUserDto.Email) != null)
            {
                return Result<UserDto>.Failure(UserErrors.EmailAlreadyExists);
            }

            var user = _mapper.Map<User>(newUserDto);

            var userRoles = validRoles.Select(role => new UserRol
            {
                User = user,
                RoleId = role.Id
            }).ToList();

            await _userRolRepository.CreateAsync(user, userRoles);

            var userDto = _mapper.Map<UserDto>(user);

            return Result<UserDto>.Success(userDto);
        }

        public async Task<Result<UserDto>> UpdateAsync(UpdateUserDto updateUserDto)
        {
            // Validar que el usuario existe
            var existingUser = await _userRepository.GetUserAsync(updateUserDto.Id);
            if (existingUser == null)
            {
                return Result<UserDto>.Failure(UserErrors.NoUsersFound);
            }

            // Validar que todos los roles proporcionados existan
            var validRoles = await _roleRepository.GetRolesByIdsAsync(updateUserDto.Roles);

            if (validRoles.Count != updateUserDto.Roles.Length)
            {
                return Result<UserDto>.Failure(UserRoleErrors.InvalidRoleData);
            }

            // Validar que el número de teléfono no se repita (excluyendo el usuario actual)
            var phoneUser = await _userRepository.PhoneNumberExitsAsync(updateUserDto.Phone);
            if (phoneUser != null && phoneUser.Id != updateUserDto.Id)
            {
                return Result<UserDto>.Failure(UserErrors.PhoneNumberAlreadyExists);
            }

            // Validar que el NID no se repita (excluyendo el usuario actual)
            var nidUser = await _userRepository.NidExitsAsync(updateUserDto.Nid);
            if (nidUser != null && nidUser.Id != updateUserDto.Id)
            {
                return Result<UserDto>.Failure(UserErrors.NidAlreadyExists);
            }

            // Validar que el correo electrónico no se repita (excluyendo el usuario actual)
            var emailUser = await _userRepository.EmailExitsAsync(updateUserDto.Email);
            if (emailUser != null && emailUser.Id != updateUserDto.Id)
            {
                return Result<UserDto>.Failure(UserErrors.EmailAlreadyExists);
            }

            existingUser.Name = updateUserDto.Name;
            existingUser.Lastname = updateUserDto.Lastname;
            existingUser.UserName = updateUserDto.UserName;
            existingUser.Email = updateUserDto.Email;
            existingUser.Nid = updateUserDto.Nid;
            existingUser.Phone = updateUserDto.Phone;
            existingUser.Description = updateUserDto.Description;

            await _userRolRepository.RemoveByUserIdAsync(updateUserDto.Id);

            var userRoles = validRoles.Select(role => new UserRol
            {
                User = existingUser,
                RoleId = role.Id
            }).ToList();

            // Guardar cambios en el usuario
            await _userRolRepository.UpdateAsync(existingUser, userRoles);

            var userDto = _mapper.Map<UserDto>(existingUser);

            return Result<UserDto>.Success(userDto);
        }

    }
}
