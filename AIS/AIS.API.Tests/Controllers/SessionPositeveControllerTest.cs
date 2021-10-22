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
        public async void GetSessions_ReturnsSessionList()
        {
            _sessionServiceMock.Setup(x => x.Get( default)).ReturnsAsync(new List<Session>());
             await _controller.GetSessions(default);
            _sessionServiceMock.Verify(x => x.Get(default), Times.Once);
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
            _sessionServiceMock.Setup(x => x.GetById(sessionId, default)).ReturnsAsync(expectedSession);
            await _controller.GetSession(9, default);
            _sessionServiceMock.Verify(x => x.GetById(9, default), Times.Once);
        }

        [Fact]
        public async Task DeleteSession_ValidId_ReturnsNull()
        {
            _sessionServiceMock.Setup(x => x.Delete(6, default)).ReturnsAsync(true);
            await _controller.Delete(6, default);
            _sessionServiceMock.Verify(x => x.Delete(6,default), Times.Once);
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
            var sessionUpdateViewModel = new SessionUpdateViewModel()
            {
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<SessionUpdateViewModel>())).Returns(sessionEntity);
            _sessionServiceMock.Setup(x => x.Put(sessionEntity, default)).ReturnsAsync(() => sessionEntity);
            await _controller.Put(6,sessionUpdateViewModel,default);
            _sessionServiceMock.Verify(x => x.Put(sessionEntity, default), Times.Once);
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
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<SessionAddViewModel>())).Returns(session);
            await _controller.Post(sessionAddViewModel, default);
            _sessionServiceMock.Verify(x => x.Add(session, default), Times.Once);
        }
    }
}