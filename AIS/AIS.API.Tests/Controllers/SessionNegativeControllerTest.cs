using AIS.API.Controllers;
using AIS.API.ViewModels;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AIS.API.Tests.Controllers
{
    public class SessionNegativeControllerTest
    {
        private readonly Mock<ISessionService> _sessionServiceMock = new();
        private readonly SessionController _controller;
        private readonly Mock<IMapper> _mapperMock = new();

        public SessionNegativeControllerTest()
        {
            _controller = new SessionController(_sessionServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetSessions_ReturnsEmptySessionList()
        {
            IEnumerable<Session> sessionsList = new List<Session>();
            IEnumerable<SessionViewModel> sessionsListViewModel = new List<SessionViewModel>();
            _sessionServiceMock.Setup(x => x.Get(default)).ReturnsAsync(sessionsList);
            _mapperMock.Setup(x => x.Map<IEnumerable<SessionViewModel>>(It.IsAny<IEnumerable<SessionViewModel>>())).Returns(sessionsListViewModel);
            var result = await _controller.GetSessions(default);
            _sessionServiceMock.Verify(x => x.Get(default), Times.Once);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetSession_NotValidId_ReturnsNull()
        {
            _sessionServiceMock.Setup(x => x.GetById(int.MaxValue, default)).ReturnsAsync(new Session());
            _mapperMock.Setup(x => x.Map<SessionViewModel>(It.IsAny<Session>())).Returns(new SessionViewModel());
            var result = await _controller.GetSession(int.MaxValue, default);
            _sessionServiceMock.Verify(x => x.GetById(int.MaxValue, default), Times.Once);
            Assert.Null(result.Company);
        }

        [Fact]
        public async Task DeleteSession_ValidId_ReturnsNull()
        {
            _sessionServiceMock.Setup(x => x.Delete(int.MinValue, default));
            await _controller.Delete(int.MinValue, default);
            _sessionServiceMock.Verify(x => x.Delete(int.MinValue, default), Times.Once);
        }

        [Fact]
        public async Task PutSession_ValidSession_ReturnsNull()
        {
            var session = new Session()
            {
                Id = int.MaxValue,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            var sessionUpdateEntity = new SessionUpdateViewModel()
            {
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };

            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<SessionUpdateViewModel>())).Returns(session);
            _sessionServiceMock.Setup(x => x.Put(session, default)).ReturnsAsync(session);
            _mapperMock.Setup(x => x.Map<SessionViewModel>(It.IsAny<Session>())).Returns(new SessionViewModel());
            var result = await _controller.Put(int.MaxValue, sessionUpdateEntity, default);
            _sessionServiceMock.Verify(x => x.Put(session, default), Times.Once);
            Assert.Null(result.Interviewee);
        }

        [Fact]
        public async Task AddSession_NotValidSession_ReturnSession()
        {
            const int number = int.MaxValue;
            var sessionEntity = new Session()
            {
                StartTime = DateTime.Today,
                CompanyId = number,
                EmployeeId = number,
                IntervieweeId = number,
                QuestionAreaId = number
            };
            var session = new SessionAddViewModel();
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<SessionAddViewModel>())).Returns(sessionEntity);
            _sessionServiceMock.Setup(x => x.Add(sessionEntity, default)).ReturnsAsync(() => sessionEntity);
            _mapperMock.Setup(x => x.Map<SessionViewModel>(It.IsAny<Session>())).Returns(new SessionViewModel());
            var result = await _controller.Post(session, default);
            _sessionServiceMock.Verify(x => x.Add(sessionEntity, default), Times.Once);
            Assert.Null(result.Company);
        }
    }
}