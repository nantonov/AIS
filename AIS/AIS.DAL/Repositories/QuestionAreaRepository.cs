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
    public class QuestionAreaRepository : GenericRepository<QuestionAreaEntity>, IQuestionAreaRepository
    {
        public QuestionAreaRepository(DatabaseContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<QuestionAreaEntity>> Get(CancellationToken ct)
        {
            var result = await _dbSet.Include(x => x.QuestionSets).ToListAsync(ct);

            return result;
        }

        public override async Task<IEnumerable<QuestionAreaEntity>> Get(Expression<Func<QuestionAreaEntity, bool>> predicate,
            CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().Include(x => x.QuestionSets).Where(predicate).ToListAsync(ct);
        }

        public override async Task<QuestionAreaEntity> GetById(int id, CancellationToken ct)
        {
            var entity = await _dbSet.AsNoTracking().Include(x => x.QuestionSets).FirstOrDefaultAsync(x => x.Id == id, ct);

            return entity;
        }
    }
}
