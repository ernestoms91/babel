using Babel.Models;

namespace Babel.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(int id);
        Task DeleteUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task<User> PhoneNumberExitsAsync (string phoneNumber);
        Task<User> EmailExitsAsync (string email);
        Task<User> NidExitsAsync(string nid);
        Task SaveChangesAsync();
    }
}
