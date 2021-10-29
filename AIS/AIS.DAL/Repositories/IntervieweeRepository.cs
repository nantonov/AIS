using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AIS.DAL.Repositories
{
    public class IntervieweeRepository : GenericRepository<IntervieweeEntity>, IIntervieweeRepository
    {
        public IntervieweeRepository(DatabaseContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<IntervieweeEntity>> Get(CancellationToken ct)
        {
            return await _dbSet.Include(x => x.Company).ToListAsync(ct);
        }

        public override async Task<IEnumerable<IntervieweeEntity>> Get(Expression<Func<IntervieweeEntity, bool>> predicate, CancellationToken ct)
        {
            return await _dbSet.Include(x => x.Company).Where(predicate).ToListAsync(ct);
        }

        public override async Task<IntervieweeEntity> GetById(int id, CancellationToken ct)
        {
            var entity = await _dbSet.Include(x => x.Company).FirstOrDefaultAsync(x => x.Id == id, ct);
            return entity;
        }

        public async Task<IEnumerable<IntervieweeEntity>> GetIncluded(CancellationToken ct)
        {
            return await Query(true).AsNoTracking().ToListAsync(ct);
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
        protected virtual IQueryable<IntervieweeEntity> Query(bool eager = false)
        {
            var query = _context.Interviewees.AsQueryable();
            if (eager)
            {
                var navigation = _context.Model.FindEntityType(typeof(IntervieweeEntity))
                    .GetDerivedTypesInclusive()
                    .SelectMany(type => type.GetNavigations())
                    .Distinct();

                foreach (var property in navigation)
                    query = query.Include(property.Name).AsSplitQuery();
            }
            return query;
        }
    }
}