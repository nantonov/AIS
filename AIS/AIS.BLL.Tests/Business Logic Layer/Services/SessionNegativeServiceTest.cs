using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.BLL.Services;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AIS.BLL.Tests.Business_Logic_Layer.Services
{
    public class SessionNegativeServiceTest
    {
        private readonly ISessionService _service;
        private readonly Mock<ISessionRepository> _sessionRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        public SessionNegativeServiceTest()
        {
            _service = new SessionService(_sessionRepoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task DeleteSession_NotValidId_ReturnsSession()
        {
            var sessionEntity = new SessionEntity()
            {
                Id = 6,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 2
            };
            var session = new Session()
            {
                Id = 6,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 2
            };
            _mapperMock.Setup(x => x.Map<SessionEntity>(It.IsAny<Session>())).Returns(sessionEntity);
            _sessionRepoMock.Setup(x => x.Delete(sessionEntity, default));
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<Session>())).Returns(session);
            await _service.Delete(int.MaxValue, default);
            var result = await _service.GetById(6, default);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetSessions_ReturnsEmptySessionList()
        {
            _sessionRepoMock.Setup(x => x.Get(default)).ReturnsAsync(new List<SessionEntity>());
            var sessions = await _service.Get(default);
            Assert.Equal(new List<Session>(), sessions);
        }

        [Fact]
        public async Task GetSession_NotValidId_ReturnsNull()
        {
            var session = new Session()
            {
                Id = 11,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            var sessionEntity = new SessionEntity()
            {
                Id = int.MaxValue,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };

            _mapperMock.Setup(x => x.Map<SessionEntity>(It.IsAny<Session>())).Returns(sessionEntity);
            _sessionRepoMock.Setup(x => x.GetById(6, default)).ReturnsAsync(sessionEntity);
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<Session>())).Returns(session);
            // Act
            var actual = await _service.GetById(session.Id, default);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(session.Id, actual.Id);
        }

        [Fact]
        public async Task PutSession_NotValidSession_ReturnsNull()
        {
            var sessionEntity = new SessionEntity()
            {
                Id = int.MinValue,
                StartTime = DateTime.Today,
                CompanyId = -3,
                EmployeeId = 5,
                IntervieweeId = -2,
                QuestionAreaId = 1
            };
            var session = new Session()
            {
                Id = int.MaxValue,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };

            _mapperMock.Setup(x => x.Map<SessionEntity>(It.IsAny<Session>())).Returns(sessionEntity);
            _sessionRepoMock.Setup(x => x.Update(sessionEntity, default)).ReturnsAsync(() => sessionEntity);
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<SessionEntity>())).Returns(session);
            var expected = await _service.Put(session, default);
            Assert.NotEqual(sessionEntity.Id, expected.Id);
            Assert.NotEqual(sessionEntity.CompanyId, expected.CompanyId);
        }

        [Fact]
        public async Task AddSession_NotValidSession_ReturnsNull()
        {
            var session = new Session();
            var sessionEntity = new SessionEntity();
            _mapperMock.Setup(x => x.Map<SessionEntity>(It.IsAny<Session>())).Returns(sessionEntity);
            _sessionRepoMock.Setup(x => x.Add(It.IsAny<SessionEntity>(), default)).ReturnsAsync(sessionEntity);
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<SessionEntity>())).Returns(session);
            // Act
            var actual = await _service.Add(session, default);

            // Assert
            Assert.Equal(0, actual.EmployeeId);
            Assert.Equal(0, actual.CompanyId);
            Assert.Null(actual.Employee);
        }
    }
}