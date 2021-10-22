using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.DAL.Repositories
{
    public class SessionRepository : ISessionRepository
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
            return Task.Run(()=> _context.Sessions.ToListAsync(ct)).Result;
        }

        public async Task<SessionEntity> GetById(int id, CancellationToken ct)
        {
            return await _context.Sessions.FindAsync(new object[] { id }, ct);
        }

        public async Task<SessionEntity> Put(SessionEntity entity, CancellationToken ct)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public async Task<bool> Delete(SessionEntity entity, CancellationToken ct)
        {
            _context.Sessions.Remove(entity);
            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}