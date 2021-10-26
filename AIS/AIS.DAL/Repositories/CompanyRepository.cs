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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DatabaseContext _context;

        public CompanyRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<CompanyEntity> Add(CompanyEntity entity, CancellationToken ct)
        {
            await 
                _context.Companies.AddAsync(entity, ct);
            await 
                _context.SaveChangesAsync(ct);
            return entity;
        }

        public async Task<IEnumerable<CompanyEntity>> Get(CancellationToken ct)
        {
            return 
                await 
                    _context
                        .Companies
                        .Include(x => x.Employees)
                        .Include(x => x.Interviewees)
                        .ToListAsync(ct);
        }

        public IEnumerable<CompanyEntity> Get(Func<CompanyEntity, bool> predicate, CancellationToken ct)
        {
            return _context.Companies.AsNoTracking().Include(x => x.Employees).Include(x => x.Interviewees).AsNoTracking().Where(predicate).ToList();
        }

        public async Task<CompanyEntity> GetById(int id, CancellationToken ct)
        {
            return await _context.Companies.FindAsync(new object[] { id }, ct);
        }

        public async Task<CompanyEntity> Update(CompanyEntity entity, CancellationToken ct)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public async Task Delete(CompanyEntity entity, CancellationToken ct)
        {
            _context.Companies.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task Delete(int id, CancellationToken ct)
        {
            var entity = await _context.Companies.FindAsync(new object[] { id }, ct);
            _context.Companies.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }
    }
}
