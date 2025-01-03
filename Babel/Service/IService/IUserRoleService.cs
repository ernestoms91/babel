using Babel.Models;
using Babel.Models.Dtos;

namespace Babel.Service.IService
{
    public interface IUserRoleService
    {
        Task<Result<UserDto>> CreateAsync(NewUserDto newUserDto);
        Task<Result<UserDto>> UpdateAsync(UpdateUserDto updateUserDto);
    }
}
