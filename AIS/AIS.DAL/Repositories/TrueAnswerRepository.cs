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
    public class TrueAnswerRepository : GenericRepository<TrueAnswerEntity>, ITrueAnswerRepository
    {
        public TrueAnswerRepository(DatabaseContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<TrueAnswerEntity>> Get(CancellationToken ct)
        {
            var result = await _dbSet.Include(x => x.Question).ToListAsync(ct);

            return result;
        }

        public override async Task<IEnumerable<TrueAnswerEntity>> Get(Expression<Func<TrueAnswerEntity, bool>> predicate, CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().Include(x => x.Question).ThenInclude(x => x.QuestionSet).Where(predicate).ToListAsync(ct);
        }

        public override async Task<TrueAnswerEntity> GetById(int id, CancellationToken ct)
        {
            var entity = await _dbSet.AsNoTracking().Include(x => x.Question).ThenInclude(x => x.QuestionSet).FirstOrDefaultAsync(x => x.Id == id, ct);

            return entity;
        }
    }
}
