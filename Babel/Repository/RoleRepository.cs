using Babel.Data;
using Babel.Models;
using Babel.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Babel.Repository
{

    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _db;

        public RoleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await _db.Roles.ToListAsync();
        }

        public async Task<Role?> GetRoleAsync(int id)
        {
            return await _db.Roles.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Role> CreateRoleAsync(Role role)
        {
            await _db.Roles.AddAsync(role);
            await _db.SaveChangesAsync();

            await _db.Entry(role).ReloadAsync();
            return role;
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            _db.Roles.Update(role);
            await _db.SaveChangesAsync();

            await _db.Entry(role).ReloadAsync();
            return role;
        }

        public async Task DeleteRoleAsync(Role role)
        {
            _db.Roles.Remove(role);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Role>> GetRolesByIdsAsync(int[] roleIds)
        {
            return await _db.Roles.Where(r => roleIds.Contains(r.Id)).ToListAsync();
        }
    }
}
