using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace AIS.DAL.Repositories
{
    public class SessionRepository : GenericRepository<SessionEntity>, ISessionRepository
    {
        public SessionRepository(DatabaseContext context) :base(context)
        {

        }

        public override async Task<IEnumerable<SessionEntity>> Get(CancellationToken ct)
        {
            var result = await _dbSet.Include(x => x.Interviewee)
                                     .Include(x => x.QuestionArea)
                                     .Include(x => x.Company)
                                     .Include(x => x.Employee)
                                     .ToListAsync(ct);

            return result;
        }

        public override async Task<IEnumerable<SessionEntity>> Get(Expression<Func<SessionEntity, bool>> predicate,
            CancellationToken ct)
        {
            return await _dbSet.AsNoTracking()
                               .Include(x => x.Employee)
                               .Include(x => x.Interviewee)
                               .Include(x => x.Company)
                               .Include(x => x.QuestionArea)
                               .Where(predicate)
                               .ToListAsync(ct);
        }

        public override async Task<SessionEntity> GetById(int id, CancellationToken ct)
        {
            var entity = await _dbSet.AsNoTracking()
                                     .Include(x => x.Employee)
                                     .Include(x => x.Interviewee)
                                     .Include(x => x.Company)
                                     .Include(x => x.QuestionArea)
                                     .ThenInclude(x => x.QuestionSets)
                                     .ThenInclude(x => x.Questions)
                                     .Include(x => x.QuestionIntervieweeAnswers)
                                     .ThenInclude(x => x.Question)
                                     .FirstOrDefaultAsync(x => x.Id == id, ct);

            return entity;
        }
    }
}