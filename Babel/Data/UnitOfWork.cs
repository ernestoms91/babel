
using Babel.Repository.IRepository;
using System.Reflection.Metadata.Ecma335;

namespace Babel.Data
{
    public class UnitOfWork : IUnitOfWork
    {
       
        public  IUserRepository UserRepository { get;  }
        public  IUserRolRepository UserRolRepository { get; }
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db, IUserRepository userRepository, IUserRolRepository userRolRepository)
        {
            _db = db;
            UserRepository = userRepository;
            UserRolRepository = userRolRepository;
        }
        public Task<int> Save()
        {
            return _db.SaveChangesAsync();
        }
    

        public void Dispose()
        {
          _db.Dispose();
        }
    }
}
