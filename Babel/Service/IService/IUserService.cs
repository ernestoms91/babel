using Babel.Models;
using Babel.Models.Dtos;

namespace Babel.Service.IService
{
    public interface IUserService
    {
        Result<List<UserDto>> GetUsers();
        Result<UserDto> GetUser(int id);
        Task<Result<UserDto>> CreateUserAsync(NewUserDto newUserDto);
        User UpdateUser(int id);
        Result<UserDto> ChangeUserStatus(int id);
    }
}
