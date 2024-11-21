using Babel.Models;

namespace Babel.Repository.IRepository
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User CreateUser(User user);
        User GetUser(int id);
        void DeleteUser(User user);
        void UpdateUser(User user);
        User PhoneNumberExits (string phoneNumber);
        User EmailExits (string email);
        User NidExits(string nid);
        void SaveChanges();
    }
}
