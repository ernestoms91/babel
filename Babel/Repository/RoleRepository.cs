using Babel.Data;
using Babel.Models;
using Babel.Repository.IRepository;

namespace Babel.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _db;

        public RoleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Role> GetRoles()
        {
            return _db.Roles
                .ToList();
        }

        public Role GetRole(int id)
        {
            return _db.Roles
                .FirstOrDefault(r => r.Id == id);
        }

        public Role CreateRole(Role role)
        {
            _db.Roles.Add(role);
            _db.SaveChanges();

            _db.Entry(role).Reload();
            return role;
        }

        public Role UpdateRole(Role role)
        {
            _db.Roles.Update(role);
            _db.SaveChanges();

            _db.Entry(role).Reload();
            return role;
        }

        public void DeleteRole(Role role)
        {
            _db.Roles.Remove(role);
            _db.SaveChanges();
        }
    }
}
