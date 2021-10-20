using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIS.DAL.Repositories
{
    public class CompanyRepository : GenericRepository<CompanyEntity>
    {
        public CompanyRepository(DatabaseContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<CompanyEntity>> Get(CancellationToken ct)
        {
            return await _dbSet.Include(x => x.Employees).Include(x => x.Interviewees).ToListAsync(ct);
        }

        public override IEnumerable<CompanyEntity> Get(Func<CompanyEntity, bool> predicate, CancellationToken ct)
        {
            return _dbSet.AsNoTracking().Include(x => x.Employees).Include(x => x.Interviewees).AsNoTracking().Where(predicate).ToList();
        }
    }
}
