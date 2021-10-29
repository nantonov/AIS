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
    public class CompanyRepository : GenericRepository<CompanyEntity>, ICompanyRepository
    {

        public CompanyRepository(DatabaseContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<CompanyEntity>> Get(CancellationToken ct)
        {
            var result = await _dbSet.Include(x => x.Employees).Include(x => x.Interviewees).ToListAsync(ct);

            return result;
        }

        public override async Task<IEnumerable<CompanyEntity>> Get(Expression<Func<CompanyEntity, bool>> predicate,
            CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().Include(x => x.Employees).Include(x => x.Interviewees)
                .Where(predicate).ToListAsync(ct);
        }

        public override async Task<CompanyEntity> GetById(int id, CancellationToken ct)
        {
            var entity = await _dbSet.AsNoTracking().Include(x => x.Employees).Include(x => x.Interviewees).FirstOrDefaultAsync(x => x.Id == id, ct);

            return entity;
        }
    }
}