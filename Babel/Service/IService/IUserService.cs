using Babel.Models;
using Babel.Models.Dtos;

namespace Babel.Service.IService
{
    public interface IUserService
    {
        Task<Result<List<UserDto>>> GetUsersAsync();
        Task<Result<UserDto>> GetUserAsync(int id);
        //Task<Result<UserDto>> CreateUserAsync(NewUserDto newUserDto);
        Task<Result<User>> UpdateUserAsync(int id);
        Task<Result<UserDto>> ChangeUserStatusAsync(int id);
    }
}



