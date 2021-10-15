﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIS.DAL.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task<IEnumerable<TEntity>> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        Task<TEntity> GetById(int id);
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
