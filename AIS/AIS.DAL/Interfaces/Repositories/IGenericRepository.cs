﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIS.DAL.Interfaces.Repositories
{
    interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity item);
        Task<IEnumerable<TEntity>> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        Task<TEntity> GetById(int id);
        Task<TEntity> Update(TEntity item);
        Task Delete(TEntity item);
    }
}
