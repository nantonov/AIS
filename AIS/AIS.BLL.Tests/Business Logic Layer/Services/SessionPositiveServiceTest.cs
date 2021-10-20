using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.BLL.Services;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using Moq;
using Moq.AutoMock;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AIS.BLL.Tests.Business_Logic_Layer.Services
{
    public class SessionPositiveServiceTest
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
            var expected = await _service.Get(default);

            Assert.NotNull(expected);

        }

        [Fact]
        public async Task GetSession_ValidId_ReturnsSessionById()
        {
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var session = new Session()
            {
                Id = 11,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };

            mocker.Setup<IGenericService<Session>, Task<Session>>(setup => setup.GetById(9, CancellationToken.None)).ReturnsAsync(session);

            var service = mocker.Get<IGenericService<Session>>();

            // Act
            var actual = await service?.GetById(9, default);

            // Assert
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
            _sessionRepoMock.Setup(x => x.Delete(sessionEntity, default)).ReturnsAsync(true);
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
            _sessionRepoMock.Setup(x => x.Put(sessionEntity, default)).ReturnsAsync(() => sessionEntity);
            var expected = await _service.Put(session, default);
            Assert.Null(expected);
        }

        [Fact]
        public async Task AddSession_ValidSession_ReturnsSession()
        {
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var session = new Session()
            {
                Id = 11,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };

            mocker.Setup<IGenericService<Session>, Task<Session>>(setup => setup.Add(session, CancellationToken.None)).ReturnsAsync(session);

            var service = mocker.Get<IGenericService<Session>>();

            // Act
            var actual = await service?.Add(session, default);

            // Assert
            Assert.Equal(session, actual);
        }
    }
}