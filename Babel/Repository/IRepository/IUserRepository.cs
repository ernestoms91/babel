using Babel.Models;

namespace Babel.Repository.IRepository
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUser(int id);
        User CreateUser(User user);
        User UpdateUser(User user);
        void DeleteUser(User user);
    }
}
