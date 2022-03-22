using AIS.DAL.Entities;
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
    public class QuestionsQuestionSetsRepository : GenericRepository<QuestionsQuestionSetsEntity>, IQuestionsQuestionSetsRepository
    {
        public QuestionsQuestionSetsRepository(DatabaseContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<QuestionsQuestionSetsEntity>> Get(CancellationToken ct)
        {
            var result = await _dbSet.Include(x => x.Question).Include(x => x.QuestionSet).ToListAsync(ct);

            return result;
        }

        public override async Task<IEnumerable<QuestionsQuestionSetsEntity>> Get(Expression<Func<QuestionsQuestionSetsEntity, bool>> predicate,
            CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().Include(x => x.Question).Include(x => x.QuestionSet).Where(predicate).ToListAsync(ct);
        }

        public override async Task<QuestionsQuestionSetsEntity> GetById(int id, CancellationToken ct)
        {
            var entity = await _dbSet.AsNoTracking().Include(x => x.Question).Include(x => x.QuestionSet).FirstOrDefaultAsync(x => x.Id == id, ct);

            return entity;
        }
        public async Task Delete(int questionSetId, int questionId, CancellationToken ct)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.QuestionSetId == questionSetId && x.QuestionId == questionId, ct);
            if (entity is not null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync(ct);
            }
        }

        public async Task AddRange(IEnumerable<QuestionsQuestionSetsEntity> questionsList, CancellationToken ct)
        {
            await _context.AddRangeAsync(questionsList, ct);
            await _context.SaveChangesAsync(ct);
        }
    }
}
