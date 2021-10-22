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
   /* public class SessionPositiveServiceTest
    {
        private readonly ISessionService _service;
        private readonly Mock<ISessionRepository> _sessionRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();


        public SessionPositiveServiceTest()
        {
            _service = new SessionService(_sessionRepoMock.Object, _mapperMock.Object);
        }
        [Fact]
        public async Task GetSessions_ReturnsSessionList()
        {
            List<SessionEntity> sessionsEntity = new()
            {
                new SessionEntity()
                {
                    Id = 11,
                    StartTime = DateTime.Today,
                    CompanyId = 5,
                    EmployeeId = 5,
                    IntervieweeId = 5,
                    QuestionAreaId = 1
                }
            };
            List<Session> sessions = new()
            {
                new Session()
                {
                    Id = 11,
                    StartTime = DateTime.Today,
                    CompanyId = 5,
                    EmployeeId = 5,
                    IntervieweeId = 5,
                    QuestionAreaId = 1
                }
            };
            _mapperMock.Setup(x => x.Map<IEnumerable<SessionEntity>>(It.IsAny<IEnumerable<Session>>())).Returns(sessionsEntity);
            _sessionRepoMock.Setup(x => x.Get(default)).ReturnsAsync(new List<SessionEntity>());
            _mapperMock.Setup(x => x.Map<IEnumerable<Session>>(It.IsAny<IEnumerable<Session>>())).Returns(sessions);
            var result = await _service.Get(default);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetSession_ValidId_ReturnsSessionById()
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
                Id = 11,
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
            Assert.Equal(session, actual);
        }

        [Fact]
        public async Task DeleteSession_ValidId_ReturnsTrue()
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
            var result = await _service.Delete(6, default);
            Assert.True(result);
        }

        [Fact]
        public async Task PutSession_ValidSession_ReturnsSession()
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

            _mapperMock.Setup(x => x.Map<SessionEntity>(It.IsAny<Session>())).Returns(sessionEntity);
            _sessionRepoMock.Setup(x => x.Put(sessionEntity, default)).ReturnsAsync(() => sessionEntity);
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<SessionEntity>())).Returns(session);
            var expected = await _service.Put(session, default);
            Assert.Equal(session, expected);
        }

        [Fact]
        public async Task AddSession_ValidSession_ReturnsSession()
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
                Id = 11,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
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
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            var sessionEntity = new SessionEntity()
            {
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            _mapperMock.Setup(x => x.Map<SessionEntity>(It.IsAny<Session>())).Returns(sessionEntity);
            _sessionRepoMock.Setup(x => x.Add(It.IsAny<SessionEntity>(), default)).ReturnsAsync(sessionEntity);
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<SessionEntity>())).Returns(session);
            // Act
            var actual = await _service.Add(session, default);

            // Assert
            Assert.Equal(session.CompanyId, actual.CompanyId);
        }
    }*/
}