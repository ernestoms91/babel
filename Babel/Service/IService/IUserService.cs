using Babel.Models;

namespace Babel.Service.IService
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUser(int id);
        User CreateUser(User user);
        User UpdateUser(int id);
        bool ChangeUserStatus(int id);
    }
}
