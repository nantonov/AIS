using AIS.DAL.Entities;
using AIS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AIS.DAL.Tests.Data_Access_Layer.Repositories.Session
{
    public class SessionPositiveRepositoryTest
    {
        private readonly DatabaseContext _context = new
        (new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options);
        private SessionRepository _repo;

        public SessionPositiveRepositoryTest()
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
            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task GetSessions_ReturnsSessionList()
        {

            await using (var context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options))
            {
                var sessionEntity = new SessionEntity()
                {
                    CompanyId = 5,
                    EmployeeId = 5,
                    IntervieweeId = 5,
                    QuestionAreaId = 1,
                    StartTime = DateTime.Today
                };

                // await _context.SaveChangesAsync();

                _repo = new SessionRepository(context);
                var test = await _repo.Add(sessionEntity, default);
                test.Id = 2;
                await _context.Sessions.AddAsync(test);
                await _context.SaveChangesAsync();
                var items = await _repo.Get(default);

                var sessionEntities = items.ToList();
                Assert.Equal(1, sessionEntities.Count);
                Assert.NotNull(sessionEntities);
            }

            /*  var id = new Random().Next();
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
              await _context.Database.EnsureDeletedAsync();*/
        }

        [Fact]
        public async Task AddSession_ValidSession_ReturnsSession()
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
            var session = await _repo.Add(sessionEntity, default);
            Assert.Equal(session.EmployeeId, sessionEntity.EmployeeId);
            Assert.NotNull(session);
            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task PutSession_ValidSession_ReturnsSession()
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

            var session = await _repo.Put(sessionEntity, default);
            Assert.Equal(id, session.Id);
            Assert.Equal(id, session.CompanyId);

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
            var result = await _repo.Delete(sessionEntity, default);
            await _context.SaveChangesAsync();
            await _context.Database.EnsureDeletedAsync();
            Assert.True(result);
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