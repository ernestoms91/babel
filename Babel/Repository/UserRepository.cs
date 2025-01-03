using Babel.Data;
using Babel.Models;
using Babel.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Babel.Repository
{
    public class UserRepository : IUserRepository
    {
           private readonly ApplicationDbContext _bd;

    public UserRepository(ApplicationDbContext bd)
    {
        _bd = bd;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        await _bd.Users.AddAsync(user);
        await _bd.SaveChangesAsync();
        return user;
    }

    public async Task DeleteUserAsync(User user)
    {
        _bd.Users.Remove(user);
        await _bd.SaveChangesAsync();
    }

    public async Task<User> GetUserAsync(int id)
    {
        return await _bd.Users
            .Include(u => u.UserRoles) // Incluye la colección de UserRoles
            .ThenInclude(ur => ur.Role) // Luego incluye la entidad Role asociada a UserRole
            .FirstOrDefaultAsync(u => u.Id == id); // Busca el usuario por ID
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _bd.Users
            .Include(u => u.UserRoles) // Incluye la relación UserRoles
                .ThenInclude(ur => ur.Role) // Incluye la relación Role a través de UserRoles
            .OrderBy(u => u.UserName) // Ordena los usuarios por UserName
            .ToListAsync(); // Convierte a lista de manera asincrónica
    }

    public async Task UpdateUserAsync(User user)
    {
        _bd.Entry(user).CurrentValues.SetValues(user);
            await _bd.SaveChangesAsync();
    }

    public async Task<User> PhoneNumberExitsAsync(string phoneNumber)
    {
        return await _bd.Users.SingleOrDefaultAsync(u => u.Phone == phoneNumber);
    }

    public async Task<User> NidExitsAsync(string nid)
    {
        return await _bd.Users.SingleOrDefaultAsync(u => u.Nid == nid);
    }

    public async Task<User> EmailExitsAsync(string email)
    {
        return await _bd.Users.SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task SaveChangesAsync()
    {
        await _bd.SaveChangesAsync();
    }

    }
}