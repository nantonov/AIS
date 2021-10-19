using AIS.BLL.Interfaces.Services;
using AIS.BLL.Mapper;
using AIS.BLL.Models;
using AIS.BLL.Services;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AIS.BLL.Tests.Business_Logic_Layer.Services
{
    public class SessionPositiveServiceTest
    {
        private readonly IGenericService<Session> _service;
        private readonly Mock<IGenericRepository<SessionEntity>> _sessionRepoMock = new();

        public SessionPositiveServiceTest()
        {
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new SessionProfile()); });
            var mapper = mockMapper.CreateMapper();
            _service = new SessionService(_sessionRepoMock.Object, mapper);
        }

        [Fact]
        public async Task GetSessions_ReturnsSessionList()
        {
            var expected = await _service.Get(default);

            Assert.NotNull(expected);

        }

      /*  [Fact]
        public void GetSessionsWithFunction_ShouldReturnListSession_WhereSessionExist()
        {
            var session = new Session()
            {
                Id = 5,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };

            var result = _service.Get(null, default);

            Assert.Equal(new List<Session>(),result);
        }*/

        [Fact]
        public async Task GetSession_ValidId_ReturnsSessionById()
        {
            const int sessionId = 5;
            var sessionEntity = new SessionEntity
            {
                Id = 5,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            _sessionRepoMock.Setup(x => x.GetById(sessionId, default)).ReturnsAsync(sessionEntity);
            var session = await _service.GetById(sessionId, default);
            Assert.Equal(sessionId, session.Id);
        }

        [Fact]
        public void DeleteSessionEntity_ShouldGenerateException()
        {
            var sessionEntity = new SessionEntity()
            {
                Id = 5,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            var session = new Session()
            {
                Id = 5,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };

            _sessionRepoMock.Setup(x => x.Delete(sessionEntity, default)).Returns(() => null);
            Task Act() => _service.Delete(session, default);
            Assert.ThrowsAsync<NotImplementedException>(Act);
        }

        [Fact]
        public void DeleteSession_ValidId_ReturnsNull()
        {
            _sessionRepoMock.Setup(x => x.Delete(5, default)).Returns(() => null);
            var result = _service.Delete(5, default);
            Assert.Null(result);
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
            _sessionRepoMock.Setup(x => x.Update(sessionEntity, default)).ReturnsAsync(() => sessionEntity);
            var expected = await _service.Put(session, default);
            Assert.Null(expected);
        }
    }
}