using AIS.API.Controllers;
using AIS.API.Mapper;
using AIS.API.ViewModels;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Mapper;
using AIS.BLL.Models;
using AIS.BLL.Services;
using AIS.DAL;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AIS.API.Tests.Controllers
{
    public class SessionPositiveControllerTest
    {
        private readonly Mock<ISessionService> _sessionControllerMock = new();
        private readonly SessionController _controller;

        public SessionPositiveControllerTest()
        {
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new SessionViewModelProfile()); });
            var mapper = mockMapper.CreateMapper();
            _controller = new SessionController(_sessionControllerMock.Object, mapper);
        }
        [Fact]
        public async Task GetSessions_ReturnsSessionList()
        {
            var expected = await _controller.GetSessions(default);

            Assert.NotNull(expected);

        }

        [Fact]
        public async Task GetSession_ValidId_ReturnsSessionById()
        {
            const int sessionId = 5;
            var expectedSession = new Session
            {
                Id = 5,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            _sessionControllerMock.Setup(x => x.GetById(sessionId, default)).ReturnsAsync(expectedSession);
            var session = await _controller.GetSession(sessionId, default);
            Assert.Equal(sessionId, session.Id);
        }

        [Fact]
        public async Task DeleteSession_ValidId_ReturnsNull()
        {
            _sessionControllerMock.Setup(x => x.Delete(6, default)).ReturnsAsync(true);
            var result = await _controller.Delete(6, default);
            Assert.True(result);
        }
        [Fact]
        public async Task PutSession_ValidSession_ReturnsSession()
        {
            var sessionEntity = new Session()
            {
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            var session = new SessionUpdateViewModel()
            {
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            _sessionControllerMock.Setup(x => x.Put(sessionEntity, default)).ReturnsAsync(() => sessionEntity);
            var expected = await _controller.Put(int.MaxValue, session, default);
            Assert.Null(expected);
        }
        [Fact]
        public async Task AddSession_ValidSession_ReturnsSession()
        {
            var sessionEntity = new SessionEntity()
            {
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            var session= new Session()
            {
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            var sessionAddViewModel = new SessionAddViewModel()
            {
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            _sessionControllerMock.Setup(x => x.Add(session, default)).ReturnsAsync(session);
            var expected = await _controller.Post(sessionAddViewModel, default);
            Assert.Null(expected);
        }

        [Fact] 
        public async Task Test()
        {
            var sessionEntity = new Session()
            {
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            var session = new SessionAddViewModel()
            {
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            DatabaseContext _context = new
           (new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())
               .Options);
            var _mockSessionRepository = new Mock<ISessionService>();
            _mockSessionRepository.Setup(x => x.Add(sessionEntity,default));

            var _mockMapper = new Mock<IMapper>();
            _mockMapper.Setup(_ => _.Map<Session>(It.IsAny<SessionProfile>())).Returns(sessionEntity);

            var _sut = new SessionController(_mockSessionRepository.Object, _mockMapper.Object);

            var result = await _sut.Post(session, default);

            Assert.Null(result);
        }
    }
}