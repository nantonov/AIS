using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.DAL.Repositories
{
    public class SessionRepository : IGenericRepository<SessionEntity>
    {
        private readonly DatabaseContext _context;
        public SessionRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<SessionEntity> Add(SessionEntity entity, CancellationToken ct)
        {
            await _context.Sessions.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public async Task<IEnumerable<SessionEntity>> Get(CancellationToken ct)
        {
            return await _context.Sessions.ToListAsync(ct);
        }

        public IEnumerable<SessionEntity> Get(Func<SessionEntity, bool> predicate, CancellationToken ct)
        {
            return _context.Sessions.Where(predicate).ToList();
        }

        public async Task<SessionEntity> GetById(int id, CancellationToken ct)
        {
            return await _context.Sessions.FindAsync(new object[] { id }, ct);
        }

        public async Task<SessionEntity> Update(SessionEntity entity, CancellationToken ct)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public async Task Delete(SessionEntity entity, CancellationToken ct)
        {
            _context.Sessions.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task Delete(int id, CancellationToken ct)
        {
            var entity = await _context.Sessions.FindAsync(new object[] { id }, ct);
            _context.Sessions.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }
    }
}