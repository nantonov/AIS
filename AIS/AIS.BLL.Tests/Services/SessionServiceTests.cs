using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.BLL.Services;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace AIS.BLL.Tests.Services
{
    public class SessionServiceTests
    {
        private readonly ISessionService _service;
        private readonly Mock<ISessionRepository> _sessionRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        public SessionServiceTests()
        {
            _service = new SessionService(_sessionRepoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetSessions_HasData_ReturnSessionList()
        {
            List<SessionEntity> sessionsEntity = new()
            {
                new SessionEntity()
                {
                    Id = 11,
                    StartedAt = DateTime.Today,
                    CompanyId = 5,
                    EmployeeId = 5,
                    IntervieweeId = 5
                }
            };
            List<Session> sessions = new()
            {
                new Session()
                {
                    Id = 11,
                    StartedAt = DateTime.Today,
                    CompanyId = 5,
                    EmployeeId = 5,
                    IntervieweeId = 5
                }
            };
            _mapperMock.Setup(x => x.Map<IEnumerable<Session>>(It.IsAny<IEnumerable<SessionEntity>>())).Returns(sessions);
            _sessionRepoMock.Setup(x => x.Get(default)).ReturnsAsync(sessionsEntity);
            var result = await _service.Get(default);
            Assert.NotNull(result);
            Assert.Equal(sessions.Count, result.Count());
            result.ShouldBeEquivalentTo(sessions);
        }

        [Fact]
        public async Task GetSessions_HasNotData_ReturnEmptySessionList()
        {
            List<SessionEntity> sessionsEntity = new()
            {
                new SessionEntity()
            };
            List<Session> sessions = new()
            {
                new Session()
            };
            _mapperMock.Setup(x => x.Map<IEnumerable<SessionEntity>>(It.IsAny<IEnumerable<Session>>())).Returns(sessionsEntity);
            _sessionRepoMock.Setup(x => x.Get(default)).ReturnsAsync(sessionsEntity);
            _mapperMock.Setup(x => x.Map<IEnumerable<Session>>(It.IsAny<IEnumerable<Session>>())).Returns(sessions);
            var result = await _service.Get(default);
            Assert.Equal(new List<Session>(), result);
        }

        [Fact]
        public async Task GetSessionById_ValidId_ReturnsSessionById()
        {
            var session = new Session()
            {
                Id = 11,
                StartedAt = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5
            };
            var sessionEntity = new SessionEntity()
            {
                Id = 11,
                StartedAt = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5
            };

            _mapperMock.Setup(x => x.Map<SessionEntity>(It.IsAny<Session>())).Returns(sessionEntity);
            _sessionRepoMock.Setup(x => x.GetById(6, default)).ReturnsAsync(sessionEntity);
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<Session>())).Returns(session);
            // Act
            var actual = await _service.GetById(session.Id, default);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(session.CompanyId, actual.CompanyId);
        }

        [Fact]
        public async Task GetSessionById_InvalidId_ReturnsNullSessionById()
        {
            var session = new Session();
            var sessionEntity = new SessionEntity();

            _mapperMock.Setup(x => x.Map<SessionEntity>(It.IsAny<Session>())).Returns(sessionEntity);
            _sessionRepoMock.Setup(x => x.GetById(int.MaxValue, default)).ReturnsAsync(sessionEntity);
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<Session>())).Returns(session);
            // Act
            var actual = await _service.GetById(int.MaxValue, default);

            // Assert
            Assert.Null(actual);
        }

        [Fact]
        public async Task DeleteSession_ValidId_ReturnsNull()
        {
            var sessionEntity = new SessionEntity()
            {
                Id = 6,
                StartedAt = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5
            };
            var session = new Session()
            {
                Id = 6,
                StartedAt = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5
            };
            _mapperMock.Setup(x => x.Map<SessionEntity>(It.IsAny<Session>())).Returns(sessionEntity);
            _sessionRepoMock.Setup(x => x.Delete(sessionEntity, default));
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<Session>())).Returns(session);
            _sessionRepoMock.Setup(x => x.GetById(6, default)).ReturnsAsync(sessionEntity);
            await _service.Delete(6, default);
            var result = await _service.GetById(6, default);
            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteSession_ValidSession_ReturnsNull()
        {
            var sessionEntity = new SessionEntity()
            {
                Id = 6,
                StartedAt = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5
            };
            var session = new Session()
            {
                Id = 6,
                StartedAt = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5
            };
            _mapperMock.Setup(x => x.Map<SessionEntity>(It.IsAny<Session>())).Returns(sessionEntity);
            _sessionRepoMock.Setup(x => x.Delete(sessionEntity, default));
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<Session>())).Returns(session);
            await _service.Delete(session, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task PutSession_ValidSession_ReturnsSession()
        {
            var sessionEntity = new SessionEntity()
            {
                Id = int.MaxValue,
                StartedAt = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5
            };
            var session = new Session()
            {
                Id = int.MaxValue,
                StartedAt = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5
            };

            _mapperMock.Setup(x => x.Map<SessionEntity>(It.IsAny<Session>())).Returns(sessionEntity);
            _sessionRepoMock.Setup(x => x.Update(sessionEntity, default)).ReturnsAsync(() => sessionEntity);
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<SessionEntity>())).Returns(session);
            var expected = await _service.Put(session, default);
            Assert.NotNull(expected);
            Assert.Equal(session, expected);
            Assert.Equal(session.EmployeeId, expected.EmployeeId);
        }
        [Fact]
        public async Task PutSession_InvalidSession_ReturnsNull()
        {
            var sessionEntity = (SessionEntity)null;

            _mapperMock.Setup(x => x.Map<SessionEntity>(It.IsAny<Session>())).Returns((SessionEntity)null);
            _sessionRepoMock.Setup(x => x.Update(sessionEntity, default)).ReturnsAsync((SessionEntity)null);
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<SessionEntity>())).Returns((Session)null);
            var result = await _service.Put(null, default);
            Assert.Null(result);
        }

        [Fact]
        public async Task AddSession_ValidSession_ReturnsSession()
        {
            var session = new Session()
            {
                Id = 11,
                StartedAt = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5
            };
            var sessionEntity = new SessionEntity()
            {
                Id = 11,
                StartedAt = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5
            };
            _mapperMock.Setup(x => x.Map<SessionEntity>(It.IsAny<Session>())).Returns(sessionEntity);
            _sessionRepoMock.Setup(x => x.Add(It.IsAny<SessionEntity>(), default)).ReturnsAsync(sessionEntity);
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<SessionEntity>())).Returns(session);
            // Act
            var actual = await _service.Add(session, default);

            // Assert
            Assert.Equal(session, actual);
        }

        [Fact]
        public async Task AddSession_ValidSessionWithOutId_ReturnsSession()
        {
            var session = new Session()
            {
                StartedAt = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5
            };
            var sessionEntity = new SessionEntity()
            {
                StartedAt = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5
            };
            _mapperMock.Setup(x => x.Map<SessionEntity>(It.IsAny<Session>())).Returns(sessionEntity);
            _sessionRepoMock.Setup(x => x.Add(It.IsAny<SessionEntity>(), default)).ReturnsAsync(sessionEntity);
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<SessionEntity>())).Returns(session);
            // Act
            var actual = await _service.Add(session, default);

            // Assert
            Assert.Equal(sessionEntity.EmployeeId, actual.EmployeeId);
            Assert.Equal(session.CompanyId, actual.CompanyId);
        }

        [Fact]
        public void GetSessionsByPredicate_ValidPredicate_ReturnsSessionList()
        {
            var id = new Random().Next();
            var sessionEntity = new List<SessionEntity>
            {
                new()
                {
                    CompanyId = id,
                    EmployeeId = id,
                    IntervieweeId = id,
                    StartedAt = DateTime.Today
                }
            };
            var session = new SessionEntity()
            {
                CompanyId = id,
                EmployeeId = id,
                IntervieweeId = id,
                StartedAt = DateTime.Today
            };

            var model = new Session()
            {
                CompanyId = id,
                EmployeeId = id,
                IntervieweeId = id,
                StartedAt = DateTime.Today
            };

            _mapperMock.Setup(x => x.Map<SessionEntity>(It.IsAny<Session>())).Returns(session);
            _sessionRepoMock.Setup(x => x.Add(sessionEntity[0], default)).ReturnsAsync(session);
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<SessionEntity>())).Returns(model);
            var result = _service.Get(x => x.Id == sessionEntity[0].Id, default);
            result.ShouldNotBeNull();
        }
    }
}