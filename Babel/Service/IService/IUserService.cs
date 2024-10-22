using Babel.Models;
using Babel.Models.Dtos;

namespace Babel.Service.IService
{
    public interface IUserService
    {
        Result<List<UserDto>> GetUsers();
        Result<UserDto> GetUser(int id);
        User CreateUser(User user);
        User UpdateUser(int id);
        Result<UserDto> ChangeUserStatus(int id);
    }
}
