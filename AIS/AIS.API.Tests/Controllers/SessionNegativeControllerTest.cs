using AIS.API.Controllers;
using AIS.API.Mapper;
using AIS.API.ViewModels;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AIS.API.Tests.Controllers
{
    public class SessionNegativeControllerTest
    {
        private readonly Mock<ISessionService> _sessionControllerMock = new();
        private readonly SessionController _controller;
        private readonly Mock<IMapper> _mapperMock = new();

        public SessionNegativeControllerTest()
        {
            _controller = new SessionController(_sessionControllerMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetSessions_ReturnsEmptySessionList()
        {
            _sessionControllerMock.Setup(x => x.Get(default)).ReturnsAsync(() => null);
            await _controller.GetSessions(default);
            _sessionControllerMock.Verify(x => x.Get(default), Times.Once);
        }

        [Fact]
        public async Task GetSession_NotValidId_ReturnsNull()
        {
            _sessionControllerMock.Setup(x => x.GetById(int.MaxValue, default)).ReturnsAsync(() => null);
            await _controller.GetSession(int.MaxValue, default);
            _sessionControllerMock.Verify(x=> x.GetById(int.MaxValue, default), Times.Once);
        }

        [Fact]
        public async Task DeleteSession_ValidId_ReturnsNull()
        {
            _sessionControllerMock.Setup(x => x.Delete(int.MinValue, default)).ReturnsAsync(false);
            await _controller.Delete(int.MinValue, default);
            _sessionControllerMock.Verify(x => x.Delete(int.MinValue, default), Times.Once);
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
            _sessionControllerMock.Setup(x => x.Put(session, default)).ReturnsAsync(session);
            await _controller.Put(int.MaxValue, sessionUpdateEntity, default);
            _sessionControllerMock.Verify(x => x.Put(session, default), Times.Once);
        }

        [Fact]
        public async Task AddSession_NotValidSession_ReturnSession()
        {
            var sessionEntity = new Session();
            var session = new SessionAddViewModel();
            _mapperMock.Setup(x => x.Map<Session>(It.IsAny<SessionAddViewModel>())).Returns(sessionEntity);
            _sessionControllerMock.Setup(x => x.Add(sessionEntity, default)).ReturnsAsync(() => sessionEntity);
            await _controller.Post(session, default);
            _sessionControllerMock.Verify(x => x.Add(sessionEntity, default), Times.Once);
        }
    }
}