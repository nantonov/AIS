using AIS.BLL.Interfaces.Services;
using AIS.BLL.Mapper;
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

        public SessionNegativeServiceTest()
        {
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new SessionProfile()); });
            var mapper = mockMapper.CreateMapper();
            _service = new SessionService(_sessionRepoMock.Object, mapper);

        }

        [Fact]
        public async Task DeleteSession_ValidId_ReturnsFalse()
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

            _sessionRepoMock.Setup(x => x.Delete(sessionEntity, default)).ReturnsAsync(false);
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
            _sessionRepoMock.Setup(x => x.GetById(int.MaxValue, default)).ReturnsAsync(() => null);
            var session = await _service.GetById(int.MaxValue, default);
            Assert.Null(session);
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
            _sessionRepoMock.Setup(x => x.Put(sessionEntity, default)).ReturnsAsync(() => null);
            var expected = await _service.Put(session, default);
            Assert.Null(expected);
        }
    }
}