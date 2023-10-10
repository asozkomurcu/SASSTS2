using SASSTS2.Domain.Common;
using SASSTS2.Domain.Repositories;

namespace SASSTS2.Domain.UWork
{
    public interface IUnitWork : IDisposable
    {
        public IRepository<T> GetRepository<T>() where T : BaseEntity;
        public Task<bool> CommitAsync();
    }
}
