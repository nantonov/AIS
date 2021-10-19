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
        public async Task GetSession_ShouldReturnListSession_WhereSessionExist()
        {
            var expected = await _service.Get(default);

            Assert.NotNull(expected);

        }
        [Fact]
        public async Task GetSessionById_ShouldReturnSession_WhereSessionWasFound()
        {
            var sessionId = 5;
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
        public async Task AddSession_ShouldReturnSession_WhereSessionValidModel()
        {
            // Arrange
            var expected = new SessionEntity()
            {
                Id = 20,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            _sessionRepoMock.Setup(x => x.Add(expected, default)).ReturnsAsync(expected);
            var session = new Session()
            {
                Id = 20,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            var result = await _service.Add(session, default);
            Assert.Equal(session, result);
        }

            [Fact]
            public void DeleteSession_ShouldNOtGenerateException_WhereModelWasFound()
            {
                _sessionRepoMock.Setup(x => x.Delete(5, default)).Returns(() => null);
                var result =  _service.Delete(5,default);
                Assert.Null(result);
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
            _sessionRepoMock.Setup(x => x.Update(sessionEntity, default)).ReturnsAsync(() => sessionEntity);
            var expected = await _service.Put(session, default);
            Assert.Null(expected);
        }
    }
}