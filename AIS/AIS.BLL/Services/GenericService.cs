using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AIS.BLL.Interfaces.Services;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;

namespace AIS.BLL.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : BaseEntity
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public async Task<TEntity> Add(TEntity item)
        {
            return await this._repository.Add(item);
        }

        public async Task<TEntity> Delete(TEntity item)
        {
            return await this._repository.Delete(item);
        }

        public async Task<TEntity> Put(TEntity item)
        {
            return await this._repository.Update(item);
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await this._repository.Get();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return this._repository.Get(predicate);
        }

        public async Task<TEntity> GetById(int id)
        {
            return await this._repository.GetById(id);
        }
    }
}
