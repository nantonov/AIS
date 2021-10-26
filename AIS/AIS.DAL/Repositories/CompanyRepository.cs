using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.DAL.Repositories
{
    public class CompanyRepository : GenericRepository<CompanyEntity>, ICompanyRepository
    {

        public CompanyRepository(DatabaseContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<CompanyEntity>> Get(CancellationToken ct)
        {
            var result = await _context.Companies.Include(x => x.Employees).Include(x => x.Interviewees).ToListAsync(ct);

            return result;
        }

        public IEnumerable<CompanyEntity> Get(Func<CompanyEntity, bool> predicate, CancellationToken ct)
        {
            return _context.Companies.AsNoTracking().Include(x => x.Employees).Include(x => x.Interviewees).Where(predicate).ToList();
        }

        public async Task<CompanyEntity> GetById(int id, CancellationToken ct)
        {
            var entity = await _context.Companies.AsNoTracking().Include(x => x.Employees).Include(x => x.Interviewees).FirstOrDefaultAsync(x => x.Id == id, ct);
            
            return entity;
        }
    }
}
