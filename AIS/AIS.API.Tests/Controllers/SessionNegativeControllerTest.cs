using AIS.API.Controllers;
using AIS.API.Mapper;
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
        private readonly Mock<ISessionService> _sessionControllerMock = new();
        private readonly SessionController _controller;

        public SessionNegativeControllerTest()
        {
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new SessionViewModelProfile()); });
            var mapper = mockMapper.CreateMapper();
            _controller = new SessionController(_sessionControllerMock.Object, mapper);
        }

        [Fact]
        public async Task GetSessions_ReturnsEmptySessionList()
        {
            _sessionControllerMock.Setup(x => x.Get(default)).ReturnsAsync(() => null);
            var sessions = await _controller.GetSessions(default);
            Assert.Equal(new List<SessionViewModel>(), sessions);
        }

        [Fact]
        public async Task GetSession_NotValidId_ReturnsNull()
        {
            _sessionControllerMock.Setup(x => x.GetById(int.MaxValue, default)).ReturnsAsync(() => null);
            var session = await _controller.GetSession(int.MaxValue, default);
            Assert.Null(session);
        }

        [Fact]
        public async Task DeleteSession_ValidId_ReturnsNull()
        {
            _sessionControllerMock.Setup(x => x.Delete(int.MinValue, default)).ReturnsAsync(false);
            var session = await _controller.Delete(int.MinValue, default);
            Assert.False(session);
        }

        [Fact]
        public async Task PutSession_ValidSession_ReturnsNull()
        {
            var sessionEntity = new Session()
            {
                Id = int.MaxValue,
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
            _sessionControllerMock.Setup(x => x.Put(sessionEntity, default)).ReturnsAsync(() => null);
            var expected = await _controller.Put(int.MaxValue, session, default);
            Assert.Null(expected);
        }
        [Fact]
        public async Task AddSession_NotValidSession_ReturnSession()
        {
            var sessionEntity = new Session()
            {
            };
            var session = new SessionAddViewModel()
            {

            };
            _sessionControllerMock.Setup(x => x.Add(sessionEntity, default)).ReturnsAsync(() => sessionEntity);
            var expected = await _controller.Post(session, default);
            Assert.Null(expected);
        }
    }
}