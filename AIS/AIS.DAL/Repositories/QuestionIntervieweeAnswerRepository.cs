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
    public class QuestionIntervieweeAnswerRepository : GenericRepository<QuestionIntervieweeAnswerEntity>, IQuestionIntervieweeAnswerRepository
    {
        public QuestionIntervieweeAnswerRepository(DatabaseContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<QuestionIntervieweeAnswerEntity>> Get(CancellationToken ct)
        {
            var result = await _dbSet.Include(x => x.Question).ThenInclude(x => x.QuestionSet).ToListAsync();

            return result;
        }

        public override async Task<IEnumerable<QuestionIntervieweeAnswerEntity>> Get(Expression<Func<QuestionIntervieweeAnswerEntity, bool>> predicate,
            CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().Include(x => x.Question).Where(predicate).ToListAsync(ct);
        }

        public override async Task<QuestionIntervieweeAnswerEntity> GetById(int id, CancellationToken ct)
        {
            var entity = await _dbSet.AsNoTracking().Include(x => x.Question).ThenInclude(x => x.QuestionSet).FirstOrDefaultAsync(x => x.Id == id, ct);

            return entity;
        }
    }
}
