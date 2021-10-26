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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext _context;

        public EmployeeRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<EmployeeEntity> Add(EmployeeEntity entity, CancellationToken ct)
        {
            await _context.Employees.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public async Task<IEnumerable<EmployeeEntity>> Get(CancellationToken ct)
        {
            return await _context.Employees.AsNoTracking().Include(x => x.Company).ToListAsync(ct);
        }

        public IEnumerable<EmployeeEntity> Get(Func<EmployeeEntity, bool> predicate, CancellationToken ct)
        {
            return _context.Employees.AsNoTracking().Include(x => x.Company).Where(predicate).ToList();
        }

        public async Task<EmployeeEntity> GetById(int id, CancellationToken ct)
        {
            return await _context.Employees.FindAsync(new object[] { id }, ct);
        }

        public async Task<EmployeeEntity> Update(EmployeeEntity entity, CancellationToken ct)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public async Task Delete(EmployeeEntity entity, CancellationToken ct)
        {
            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task Delete(int id, CancellationToken ct)
        {
            var entity = await _context.Employees.FindAsync(new object[] { id }, ct);
            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }
    }
}
