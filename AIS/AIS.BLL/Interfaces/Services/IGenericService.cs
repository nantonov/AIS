using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIS.BLL.Interfaces.Services
{
    public interface IGenericService<TEntity>
    {
        Task<TEntity> Add(TEntity item);
        Task<IEnumerable<TEntity>> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        Task<TEntity> GetById(int id);
        Task<TEntity> Put(TEntity item);
        Task Delete(TEntity item);
    }
}
