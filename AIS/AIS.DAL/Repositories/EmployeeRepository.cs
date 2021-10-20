using AIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.DAL.Repositories
{
    public class EmployeeRepository : GenericRepository<EmployeeEntity>
    {
        public EmployeeRepository(DatabaseContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<EmployeeEntity>> Get(CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().Include(x => x.Company).ToListAsync(ct);
        }

        public override IEnumerable<EmployeeEntity> Get(Func<EmployeeEntity, bool> predicate, CancellationToken ct)
        {
            return _dbSet.AsNoTracking().Include(x => x.Company).Where(predicate).ToList();
        }
    }
}
