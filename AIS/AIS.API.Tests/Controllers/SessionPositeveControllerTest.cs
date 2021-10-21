using AIS.API.Controllers;
using AIS.API.ViewModels;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.BLL.Tests.Business_Logic_Layer.Services;
using AutoMapper;
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
        private readonly Mock<IMapper> _mapperMock = new();

        public SessionPositiveControllerTest()
        {
            _controller = new SessionController(_sessionControllerMock.Object, _mapperMock.Object);
        }
        [Fact]
        public async void GetSessions_ReturnsSessionList()
        {
            _sessionControllerMock.Setup(x => x.Get(default));
            var allSessions = await _controller.GetSessions(default);
            Assert.NotNull(allSessions);

        }

        [Fact]
        public async Task GetSession_ValidId_ReturnsSessionById()
        {
            const int sessionId = 9;
            var expectedSession = new Session
            {
                Id = 9,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            _sessionControllerMock.Setup(x => x.Add(expectedSession, default)).ReturnsAsync(expectedSession);
            _sessionControllerMock.Setup(x => x.GetById(sessionId, default)).ReturnsAsync(expectedSession);

            await new SessionPositiveServiceTest().AddSession_ValidSession_ReturnsSession();

            var session = new SessionPositiveServiceTest().GetSession_ValidId_ReturnsSessionById();
            Assert.NotNull(session);
        }

        [Fact]
        public async Task DeleteSession_ValidId_ReturnsNull()
        {
            _sessionControllerMock.Setup(x => x.Delete(6, default)).ReturnsAsync(true);
            var result = await _controller.Delete(6, default);
            Assert.True(result);
        }
        [Fact]
        public void PutSession_ValidSession_ReturnsSession()
        {
            var sessionEntity = new Session()
            {
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            _sessionControllerMock.Setup(x => x.Add(sessionEntity, default)).ReturnsAsync(() => sessionEntity);

            _sessionControllerMock.Setup(x => x.Put(sessionEntity, default)).ReturnsAsync(() => sessionEntity);
            var expected = 
                new SessionPositiveServiceTest().PutSession_ValidSession_ReturnsSession();
            Assert.NotNull(expected);
        }
        [Fact]
        public async Task AddSession_ValidSession_ReturnsSession()
        {
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
    }
}