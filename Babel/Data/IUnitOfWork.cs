using Babel.Repository.IRepository;

namespace Babel.Data
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository UserRepository { get; }
        public IUserRolRepository UserRolRepository { get; }
        Task<int> Save();
    }
}
