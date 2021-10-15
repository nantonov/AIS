using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AIS.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AIS.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DatabaseContext context)
        {
            this._context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Get(CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().ToListAsync(ct);
        }

        public async Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate, CancellationToken ct)
        {
            return await Task.FromResult(_dbSet.Where(predicate).ToList());
        }

        public async Task<TEntity> GetById(int id, CancellationToken ct)
        {
            return await _dbSet.FindAsync(new object[] { id }, ct);
        }

        public async Task<TEntity> Update(TEntity item, CancellationToken ct)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync(ct);
            return item;
        }

        public async Task Delete(TEntity item, CancellationToken ct)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync(ct);
        }
        
        public async Task<TEntity> Add(TEntity item, CancellationToken ct)
        {
            _dbSet.Add(item);
            await _context.SaveChangesAsync(ct);
            return item;
        }
    }
}
