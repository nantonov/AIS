using AIS.API.Controllers;
using AIS.API.ViewModels.Session;
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
    public class SessionPositiveControllerTest
    {
        private readonly Mock<ISessionService> _sessionServiceMock = new();
        private readonly SessionController _controller;
        private readonly Mock<IMapper> _mapperMock = new();

        public SessionPositiveControllerTest()
        {
            _controller = new SessionController(_sessionServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetSessions_HasData_ReturnsSessionList()
        {
            IEnumerable<Session> sessionsList = new List<Session>()
            {
                new()
                {
                    Id = 9,
                    StartedAt = DateTime.Today,
                    EmployeeId = 5,
                    IntervieweeId = 5
                }
            };
            IEnumerable<SessionViewModel> sessionsListViewModel = new List<SessionViewModel>()
            {
                new()
                {
                    Id = 9,
                    EmployeeId = 5,
                    IntervieweeId = 5
                }
            };
            _sessionServiceMock.Setup(x => x.Get(default)).ReturnsAsync(sessionsList);
            _mapperMock.Setup(x => x.Map<IEnumerable<SessionViewModel>>(It.IsAny<IEnumerable<SessionViewModel>>()))
                .Returns(sessionsListViewModel);
            var result = await _controller.GetSessions(default);
            _sessionServiceMock.Verify(x => x.Get(default), Times.Once);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetSession_ValidId_ReturnsSessionById()
        {
            var expectedSession = new Session
            {
                Id = 9,
                StartedAt = DateTime.Today,
                EmployeeId = 5,
                IntervieweeId = 5
            };
            var sessionViewModel = new SessionViewModel
            {
                Id = 9,
                EmployeeId = 5,
                IntervieweeId = 5
            };
            _sessionServiceMock.Setup(x => x.GetById(9, default)).ReturnsAsync(expectedSession);
            _mapperMock.Setup(x => x.Map<SessionViewModel>(It.IsAny<Session>())).Returns(sessionViewModel);
            var result = await _controller.GetSession(9, default);
            _sessionServiceMock.Verify(x => x.GetById(9, default), Times.Once);
            Assert.Equal(expectedSession.Id, result.Id);
        }

        [Fact]
        public async Task DeleteSession_ValidId_ReturnsNull()
        {
            _sessionServiceMock.Setup(x => x.Delete(6, default));
            await _controller.Delete(6, default);
            _sessionServiceMock.Verify(x => x.Delete(6, default), Times.Once);
        }

        [Fact]
        public async Task PutSession_ValidSession_ReturnsSession()
        {

            var session = new Session()
            {
                Id = 5,
                StartedAt = DateTime.Today,
                EmployeeId = 5,
                IntervieweeId = 5
            };
            var sessionUpdateEntity = new SessionUpdateViewModel()
            {
                EmployeeId = 5,
                IntervieweeId = 5
            };
            var sessionViewModel = new SessionViewModel()
            {
                Id = 5,
                EmployeeId = 5,
                IntervieweeId = 5
            };

            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<SessionUpdateViewModel>())).Returns(session);
            _sessionServiceMock.Setup(x => x.Put(session, default)).ReturnsAsync(session);
            _mapperMock.Setup(x => x.Map<SessionViewModel>(It.IsAny<Session>())).Returns(sessionViewModel);
            var result = await _controller.Put(5, sessionUpdateEntity, default);
            _sessionServiceMock.Verify(x => x.Put(session, default), Times.Once);
            Assert.Equal(sessionViewModel, result);
        }

        [Fact]
        public async Task AddSession_ValidSession_ReturnsSession()
        {
            var sessionEntity = new Session()
            {
                StartedAt = DateTime.Today,
                EmployeeId = 5,
                IntervieweeId = 5
            };
            var sessionViewModel = new SessionViewModel()
            {
                EmployeeId = 5,
                IntervieweeId = 5
            };
            var session = new SessionAddViewModel();
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<SessionAddViewModel>())).Returns(sessionEntity);
            _sessionServiceMock.Setup(x => x.Add(sessionEntity, default)).ReturnsAsync(sessionEntity);
            _mapperMock.Setup(x => x.Map<SessionViewModel>(It.IsAny<Session>())).Returns(sessionViewModel);
            var result = await _controller.Post(session, default);
            _sessionServiceMock.Verify(x => x.Add(sessionEntity, default), Times.Once);
            Assert.Equal(sessionViewModel, result);
        }
    }
}