﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AIS.DAL.Repositories
{
    public class IntervieweeRepository : GenericRepository<IntervieweeEntity>, IIntervieweeRepository
    {
        public IntervieweeRepository(DatabaseContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<IntervieweeEntity>> Get(CancellationToken ct)
        {
            return await _context.Interviewees.Include(x => x.Company).ToListAsync(ct);
        }

        public IEnumerable<IntervieweeEntity> Get(Func<IntervieweeEntity, bool> predicate, CancellationToken ct)
        {
            return _context.Interviewees.Include(x => x.Company).Where(predicate).ToList();
        }

        public async Task<IntervieweeEntity> GetById(int id, CancellationToken ct)
        {
            var entity = await _context.Interviewees.Include(x => x.Company).FirstOrDefaultAsync(x => x.Id == id, ct);

            return entity;
        }
    }
}
