using AIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return await _context.Employees.AsNoTracking().Include(x => x.Company).ToListAsync(ct);
        }

        public override IEnumerable<EmployeeEntity> Get(Func<EmployeeEntity, bool> predicate, CancellationToken ct)
        {
            return _context.Employees.AsNoTracking().Include(x => x.Company).Where(predicate).ToList();
        }

        public override async Task<EmployeeEntity> GetById(int id, CancellationToken ct)
        {
            return await _context.Employees.Include(x => x.Company).FirstOrDefaultAsync(x => x.Id == id, ct);
        }
    }
}
