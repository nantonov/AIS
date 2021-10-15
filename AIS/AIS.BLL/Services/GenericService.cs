using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AIS.BLL.Interfaces.Services;
using AIS.DAL.Interfaces.Repositories;

namespace AIS.BLL.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }
        
        public Task<TEntity> Add(TEntity entity, CancellationToken ct)
        {
            return this._repository.Add(entity, ct);
        }

        public Task Delete(TEntity entity, CancellationToken ct)
        {
            return this._repository.Delete(entity, ct);
        }

        public Task<TEntity> Put(TEntity entity, CancellationToken ct)
        {
            return this._repository.Update(entity, ct);
        }

        public Task<IEnumerable<TEntity>> Get(CancellationToken ct)
        {
            return this._repository.Get(ct);
        }

        public Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate, CancellationToken ct)
        {
            return this._repository.Get(predicate, ct);
        }

        public Task<TEntity> GetById(int id, CancellationToken ct)
        {
            return this._repository.GetById(id, ct);
        }
    }
}
