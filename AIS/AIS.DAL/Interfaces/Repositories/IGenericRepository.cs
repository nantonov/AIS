using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.DAL.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity, CancellationToken ct);
        Task<IEnumerable<TEntity>> Get(CancellationToken ct);
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate, CancellationToken ct);
        Task<TEntity> GetById(int id, CancellationToken ct);
        Task<TEntity> Update(TEntity entity, CancellationToken ct);
        Task Delete(TEntity entity, CancellationToken ct);
        Task Delete(int id, CancellationToken ct);
    }
}
