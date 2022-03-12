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
    public class QuestionSetRepository : GenericRepository<QuestionSetEntity>, IQuestionSetRepository
    {
        public QuestionSetRepository(DatabaseContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<QuestionSetEntity>> Get(CancellationToken ct)
        {
            var result = await _dbSet.Include(x => x.QuestionAreas).Include(x => x.Questions).ToListAsync(ct);

            return result;
        }

        public override async Task<IEnumerable<QuestionSetEntity>> Get(Expression<Func<QuestionSetEntity, bool>> predicate,
            CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().Include(x => x.QuestionAreas).Include(x => x.Questions).Where(predicate).ToListAsync(ct);
        }

        public override async Task<QuestionSetEntity> GetById(int id, CancellationToken ct)
        {
            var entity = await _dbSet.AsNoTracking().Include(x => x.QuestionAreas).Include(x => x.Questions).ThenInclude(x=> x.TrueAnswer).FirstOrDefaultAsync(x => x.Id == id, ct);

            return entity;
        }
    }
}
