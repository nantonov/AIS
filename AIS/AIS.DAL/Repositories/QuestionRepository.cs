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
    public class QuestionRepository : GenericRepository<QuestionEntity>, IQuestionRepository
    {
        public QuestionRepository(DatabaseContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<QuestionEntity>> Get(CancellationToken ct)
        {
            var result = await _dbSet.Include(x => x.QuestionSets).ThenInclude(x => x.QuestionAreas)
                                     .Include(x => x.TrueAnswer).ToListAsync(ct);

            return result;
        }

        public override async Task<IEnumerable<QuestionEntity>> Get(Expression<Func<QuestionEntity, bool>> predicate,
            CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().Include(x => x.QuestionSets).Include(x => x.TrueAnswer).Where(predicate).ToListAsync(ct);
        }

        public override async Task<QuestionEntity> GetById(int id, CancellationToken ct)
        {
            var entity = await _dbSet.AsNoTracking().Include(x => x.QuestionSets).Include(x => x.TrueAnswer).FirstOrDefaultAsync(x => x.Id == id, ct);

            return entity;
        }
    }
}
