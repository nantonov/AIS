using AIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AIS.DAL.Interfaces.Repositories;

namespace AIS.DAL.Repositories
{
    public class EmployeeRepository : GenericRepository<EmployeeEntity>, IEmployeeRepository
    {
        public EmployeeRepository(DatabaseContext context) : base(context)
        {
        }
        
        public override async Task<IEnumerable<EmployeeEntity>> Get(CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().Include(x => x.Company).ToListAsync(ct);
        }

        public override async Task<IEnumerable<EmployeeEntity>> Get(Expression<Func<EmployeeEntity, bool>> predicate, CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().Include(x => x.Company).Where(predicate).ToListAsync(ct);
        }

        public override async Task<EmployeeEntity> GetById(int id, CancellationToken ct)
        {
            return await _dbSet.Include(x => x.Company).FirstOrDefaultAsync(x => x.Id == id, ct);
        }
    }
}
