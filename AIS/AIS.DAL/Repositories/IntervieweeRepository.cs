﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AIS.DAL.Repositories
{
    class IntervieweeRepository : IIntervieweeRepository
    {
        private readonly DatabaseContext _context;

        public IntervieweeRepository(DatabaseContext context)
        {
            this._context = context;
        }

        public async Task<IntervieweeEntity> Add(IntervieweeEntity entity, CancellationToken ct)
        {
            await _context.Interviewees.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public async Task<IEnumerable<IntervieweeEntity>> Get(CancellationToken ct)
        {
            return await _context.Interviewees.ToListAsync(ct);
        }

        public async Task<IntervieweeEntity> GetById(int id, CancellationToken ct)
        {
            return await _context.Interviewees.FindAsync(new object[] {id}, ct);
        }

        public async Task<IntervieweeEntity> Update(IntervieweeEntity entity, CancellationToken ct)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public async Task Delete(int id, CancellationToken ct)
        {
            var entity = await _context.Interviewees.FindAsync(new object[] { id }, ct);
            _context.Interviewees.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }
    }
}
