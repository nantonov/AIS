using System;
using System.Collections.Generic;
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
        
        public Task<TEntity> Add(TEntity item)
        {
            return this._repository.Add(item);
        }

        public Task Delete(TEntity item)
        {
            return this._repository.Delete(item);
        }

        public Task<TEntity> Put(TEntity item)
        {
            return this._repository.Update(item);
        }

        public Task<IEnumerable<TEntity>> Get()
        {
            return this._repository.Get();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return this._repository.Get(predicate);
        }

        public Task<TEntity> GetById(int id)
        {
            return this._repository.GetById(id);
        }
    }
}
