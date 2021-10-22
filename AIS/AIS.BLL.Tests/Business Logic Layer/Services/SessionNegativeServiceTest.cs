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
   /* public class SessionNegativeServiceTest
    {
        private readonly ISessionService _service;
        private readonly Mock<ISessionRepository> _sessionRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        public SessionNegativeServiceTest()
        {
            _service = new SessionService(_sessionRepoMock.Object, _mapperMock.Object);

        }

        [Fact]
        public async Task DeleteSession_ValidId_ReturnsFalse()
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
            _sessionRepoMock.Setup(x => x.Delete(sessionEntity, default)).ReturnsAsync(true);
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<Session>())).Returns(session);
            _sessionRepoMock.Setup(x => x.GetById(6, default)).ReturnsAsync(sessionEntity);
            var result = await _service.Delete(int.MaxValue, default);
            Assert.False(result);
        }

        [Fact]
        public async Task GetSessions_ReturnsEmptySessionList()
        {
            _sessionRepoMock.Setup(x => x.Get(default)).ReturnsAsync(() => null);
            var sessions = await _service.Get(default);
            Assert.Equal(new List<Session>(), sessions);
        }

        [Fact]
        public async Task GetSession_NotValidId_ReturnsNull()
        {
            _mapperMock.Setup(x => x.Map<SessionEntity>(It.IsAny<Session>())).Returns(new SessionEntity());
            _sessionRepoMock.Setup(x => x.GetById(6, default)).ReturnsAsync(new SessionEntity());
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<Session>())).Returns(new Session());
            // Act
            var actual = await _service.GetById(int.MaxValue, default);

            // Assert
            Assert.NotEqual(int.MaxValue, actual.Id);
        }

        [Fact]
        public async Task PutSession_ValidSession_ReturnsNull()
        {
             var sessionEntity = new SessionEntity()
            {
                Id = int.MaxValue,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
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

            _mapperMock.Setup(x => x.Map<SessionEntity>(It.IsAny<Session>())).Returns(new SessionEntity());
            _sessionRepoMock.Setup(x => x.Put(sessionEntity, default)).ReturnsAsync(() => sessionEntity);
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<SessionEntity>())).Returns(new Session());
            var expected = await _service.Put(session, default);
            Assert.NotEqual(session, expected);
        }
    }*/
}