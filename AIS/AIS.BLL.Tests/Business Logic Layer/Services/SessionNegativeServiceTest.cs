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
        private readonly IGenericService<Session> _service;
        private readonly Mock<IGenericRepository<SessionEntity>> _sessionRepoMock = new();

        public SessionNegativeServiceTest()
        {
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new SessionProfile()); });
            var mapper = mockMapper.CreateMapper();
            _service = new SessionService(_sessionRepoMock.Object, mapper);

        }
        [Fact]
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

            Assert.Equal(new List<Session>(), result);

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
        public async Task GetSessionList_ShouldReturnNull_WhereSessionNotExist()
        {
            _sessionRepoMock.Setup(x => x.Get(default)).ReturnsAsync(() => null);
            var sessions = await _service.Get(default);
            Assert.Equal(new List<Session>(), sessions);
        }
        [Fact]
        public async Task GetSessionById_ShouldReturnNull_WhereSessionNotFound()
        {
            _sessionRepoMock.Setup(x => x.GetById(int.MaxValue, default)).ReturnsAsync(() => null);
            var session = await _service.GetById(int.MaxValue, default);
            Assert.Null(session);
        }

        [Fact]
        public void DeleteSession_NotShouldGenerateException_WhereModelNotFound()
        {
            _sessionRepoMock.Setup(x => x.Delete(int.MinValue, default)).Returns(() => null);
            var session = _service.Delete(int.MinValue, default);
            Assert.Null(session);
        }

        [Fact]
        public async Task UpdateSession_ShouldReturnValidModel_WhereModelWasFound()
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
            _sessionRepoMock.Setup(x => x.Update(sessionEntity, default)).ReturnsAsync(() => null);
            var expected = await _service.Put(session, default);
            Assert.Null(expected);
        }
    }
}