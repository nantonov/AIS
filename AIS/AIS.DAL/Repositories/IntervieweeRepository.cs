using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AIS.DAL.Repositories
{
    public class IntervieweeRepository : IGenericRepository<IntervieweeEntity>
    {
        private readonly DatabaseContext _context;

        public IntervieweeRepository(DatabaseContext context)
        {
            this._context = context;
        }

        public async Task<IntervieweeEntity> Add(IntervieweeEntity entity, CancellationToken ct)
        {
            await _context.Interviewees.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public async Task<IEnumerable<IntervieweeEntity>> Get(CancellationToken ct)
        {
            return await _context.Interviewees.Include(x => x.Company).ToListAsync(ct);
        }

        public IEnumerable<IntervieweeEntity> Get(Func<IntervieweeEntity, bool> predicate, CancellationToken ct)
        {
            return _context.Interviewees.Include(x => x.Company).Where(predicate).ToList();
        }

        public async Task<IntervieweeEntity> GetById(int id, CancellationToken ct)
        {
            return await _context.Interviewees.FindAsync(new object[] {id}, ct);
        }

        public async Task<IntervieweeEntity> Update(IntervieweeEntity entity, CancellationToken ct)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public async Task Delete(IntervieweeEntity entity, CancellationToken ct)
        {
            _context.Interviewees.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task Delete(int id, CancellationToken ct)
        {
            var entity = await _context.Interviewees.FindAsync(new object[] { id }, ct);
            _context.Interviewees.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }
    }
}
