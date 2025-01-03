using Babel.Models;

namespace Babel.Repository.IRepository
{
    public interface IUserRolRepository
    {

        Task CreateAsync(User user, List<UserRol> userRoles);
        Task UpdateAsync(User user, List<UserRol> userRoles);
        Task RemoveByUserIdAsync(int id);
        Task SaveChangesAsync();

    }
}
