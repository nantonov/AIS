using AIS.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DatabaseContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Get(CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().ToListAsync(ct);
        }

        public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate, CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync(ct);
        }

        public virtual async Task<TEntity> GetById(int id, CancellationToken ct)
        {
            return await _dbSet.FindAsync(new object[] { id }, ct);
        }

        public async Task<TEntity> Update(TEntity entity, CancellationToken ct)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public async Task Delete(TEntity entity, CancellationToken ct)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }
        public async Task Delete(int id, CancellationToken ct)
        {
            var entity = await _dbSet.FindAsync(new object[] { id }, ct);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<TEntity> Add(TEntity entity, CancellationToken ct)
        {
            await _dbSet.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);
            return entity;
        }
    }
}