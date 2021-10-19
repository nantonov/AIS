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
using AIS.DAL.Entities;
using Xunit;

namespace AIS.API.Tests.Controllers
{
    public class SessionNegativeControllerTest
    {
        private readonly Mock<IGenericService<Session>> _sessionControllerMock = new();
        private readonly SessionController _controller;
        private readonly IMapper _mapper;

        public SessionNegativeControllerTest()
        {
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new SessionViewModelProfile()); });
            _mapper = mockMapper.CreateMapper();
            _controller = new SessionController(_sessionControllerMock.Object, _mapper);
        }
        [Fact]
        public async Task GetSession_ShouldReturnNull_WhereSessionNotExist()
        {
            _sessionControllerMock.Setup(x => x.Get(default)).ReturnsAsync(() => null);
            var sessions = await _controller.GetSessions(default);
            Assert.Equal(new List<SessionViewModel>(), sessions);
        }
        [Fact]
        public async Task GetSessionById_ShouldReturnNull_WhereSessionNotFound()
        {
           _sessionControllerMock.Setup(x => x.GetById(int.MaxValue, default)).ReturnsAsync(() => null);
            var session = await _controller.GetSession(int.MaxValue, default);
            Assert.Null(session);
        }

        [Fact]
        public void DeleteSession_ShouldNOtGenerateException_WhereModelWasFound()
        {
            _sessionControllerMock.Setup(x => x.Delete(int.MinValue, default)).Returns(() => null);
            var session = _controller.Delete(int.MinValue, default);
            Assert.Null(session);
        }

        [Fact]
        public async Task UpdateSession_ShouldReturnNull_WhereModelNotValid()
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
    }
}