using AIS.DAL.Entities;
using AIS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace AIS.DAL.Tests.Repositories
{
    public class SessionRepositoryTest
    {
        private readonly DatabaseContext _context = new
        (new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options);
        private readonly SessionRepository _repo;

        public SessionRepositoryTest()
        {
            _repo = new SessionRepository(_context);
        }

        [Fact]
        public async Task GetSession_ValidId_ReturnsSessionById()
        {
            var id = new Random().Next();
            var sessionEntity = new SessionEntity()
            {
                Id = id,
                CompanyId = id,
                EmployeeId = id,
                IntervieweeId = id,
                QuestionAreaId = id,
                StartTime = DateTime.Today
            };
            await _context.Sessions.AddAsync(sessionEntity);
            await _context.SaveChangesAsync();
            var session = await _repo.GetById(id, default);
            Assert.Equal(id, session.Id);
            Assert.Equal(id, session.CompanyId);
            Assert.Equal(id, session.IntervieweeId);
            Assert.Equal(id, session.QuestionAreaId);
            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task GetSessions_HasData_ReturnsSessionList()
        {
            var id = new Random().Next();
            var sessionEntity = new SessionEntity()
            {
                Id = id,
                CompanyId = id,
                EmployeeId = id,
                IntervieweeId = id,
                QuestionAreaId = id,
                StartTime = DateTime.Today
            };
            await _context.Sessions.AddAsync(sessionEntity);
            await _context.SaveChangesAsync();
            var sessions = await _repo.Get(default);

            Assert.IsType<List<SessionEntity>>(sessions);
            Assert.NotEmpty(sessions);
            Assert.NotNull(sessions);
            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task AddSession_ValidSession_ReturnsSession()
        {
            var id = new Random().Next();
            var sessionEntity = new SessionEntity()
            {
                CompanyId = id,
                EmployeeId = id,
                IntervieweeId = id,
                QuestionAreaId = id,
                StartTime = DateTime.Today
            };
            var session = await _repo.Add(sessionEntity, default);
            Assert.Equal(session.EmployeeId, sessionEntity.EmployeeId);
            Assert.NotNull(session);
            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task AddSession_InvalidSession_ThrowException()
        {
            await _repo.Add(null, default).ShouldThrowAsync(typeof(ArgumentNullException));

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task PutSession_ValidSessionEntity_ReturnsSession()
        {
            var id = new Random().Next();
            var sessionEntity = new SessionEntity()
            {
                Id = id,
                CompanyId = id,
                EmployeeId = id,
                IntervieweeId = id,
                QuestionAreaId = id,
                StartTime = DateTime.Today
            };
            var updateEntity = new SessionEntity()
            {
                Id = id,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 5,
                StartTime = DateTime.Today
            };

            await _context.Sessions.AddAsync(sessionEntity);
            await _context.SaveChangesAsync();
            _context.Entry(sessionEntity).State = EntityState.Detached;
            var session = await _repo.Update(updateEntity, default);
            Assert.Equal(id, session.Id);
            Assert.Equal(updateEntity.CompanyId, session.CompanyId);
            Assert.Equal(updateEntity.IntervieweeId, session.IntervieweeId);
            Assert.Equal(updateEntity.QuestionAreaId, session.QuestionAreaId);

            await _context.Database.EnsureDeletedAsync();
        }
        [Fact]
        public async Task DeleteSession_ValidSessionEntity_ReturnsNull()
        {
            var id = new Random().Next();
            var sessionEntity = new SessionEntity()
            {
                Id = id,
                CompanyId = id,
                EmployeeId = id,
                IntervieweeId = id,
                QuestionAreaId = id,
                StartTime = DateTime.Today
            };

            await _context.Sessions.AddAsync(sessionEntity);
            await _context.SaveChangesAsync();
            await _repo.Delete(sessionEntity, default).ShouldNotThrowAsync();
            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task DeleteSession_ValidId_ReturnsNull()
        {
            var id = new Random().Next();
            var sessionEntity = new SessionEntity()
            {
                Id = id,
                CompanyId = id,
                EmployeeId = id,
                IntervieweeId = id,
                QuestionAreaId = id,
                StartTime = DateTime.Today
            };

            await _context.Sessions.AddAsync(sessionEntity);
            await _context.SaveChangesAsync();
            await _repo.Delete(id, default).ShouldNotThrowAsync();
            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task DeleteSession_InvalidSession_ThrowsException()
        {
            await _repo.Delete(null, default).ShouldThrowAsync(typeof(ArgumentNullException));
            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task DeleteSession_InvalidId_ThrowsException()
        {
            await _repo.Delete(int.MaxValue, default).ShouldThrowAsync(typeof(ArgumentNullException));
            await _context.Database.EnsureDeletedAsync();
        }


        [Fact]
        public async Task SessionExists_ValidId_ReturnsTrue()
        {
            var id = new Random().Next();
            var sessionEntity = new SessionEntity()
            {
                Id = id,
                CompanyId = id,
                EmployeeId = id,
                IntervieweeId = id,
                QuestionAreaId = id,
                StartTime = DateTime.Today
            };

            await _context.Sessions.AddAsync(sessionEntity);
            await _context.SaveChangesAsync();

            var session = _repo.Get(default);
            Assert.NotNull(session);
            await _context.Database.EnsureDeletedAsync();
        }
    }
}