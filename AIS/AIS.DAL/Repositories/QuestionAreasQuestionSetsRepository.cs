using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.DAL.Repositories
{
    public class QuestionAreasQuestionSetsRepository : GenericRepository<QuestionAreasQuestionSetsEntity>, IQuestionAreasQuestionSetsRepository
    {
        public QuestionAreasQuestionSetsRepository(DatabaseContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<QuestionAreasQuestionSetsEntity>> Get(CancellationToken ct)
        {
            var result = await _dbSet.Include(x => x.QuestionSet).Include(x => x.QuestionArea).ToListAsync(ct);

            return result;
        }

        public override async Task<IEnumerable<QuestionAreasQuestionSetsEntity>> Get(Expression<Func<QuestionAreasQuestionSetsEntity, bool>> predicate,
            CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().Include(x => x.QuestionSet).Include(x => x.QuestionArea).Where(predicate).ToListAsync(ct);
        }

        public override async Task<QuestionAreasQuestionSetsEntity> GetById(int id, CancellationToken ct)
        {
            var entity = await _dbSet.AsNoTracking().Include(x => x.QuestionSet).Include(x => x.QuestionArea).FirstOrDefaultAsync(x => x.Id == id, ct);

            return entity;
        }
    }
}
