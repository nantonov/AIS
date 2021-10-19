using AIS.API.Controllers;
using AIS.API.ViewModels;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Moq;
using System;
using System.Threading.Tasks;
using AIS.API.Mapper;
using Xunit;

namespace AIS.API.Tests.Controllers
{
    public class SessionPositiveControllerTest
    {
        private readonly Mock<IGenericService<Session>> _sessionControllerMock = new();
        private readonly SessionController _controller;
        private readonly IMapper _mapper;

        public SessionPositiveControllerTest()
        {
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new SessionViewModelProfile()); });
            _mapper = mockMapper.CreateMapper();
            _controller = new SessionController(_sessionControllerMock.Object, _mapper);
        }
        [Fact]
        public async Task GetSession_ShouldReturnListSession_WhereSessionExist()
        {
            var expected = await _controller.GetSessions(default);

            Assert.NotNull(expected);

        }
        [Fact]
        public async Task GetSessionById_ShouldReturnSession_WhereSessionWasFound()
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
        public async Task AddSession_ShouldReturnSession_WhereSessionValidModel()
        {
            var expected = new Session()
            {
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            _sessionControllerMock.Setup(x => x.Add(expected, default)).ReturnsAsync(expected);
            var session = new SessionAddViewModel()
            {
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };
            var result = _mapper.Map<SessionAddViewModel>(await _controller.Post(session, default));
            Assert.Equal(session, result);
        }

        [Fact]
        public void DeleteSession_ShouldNOtGenerateException_WhereModelWasFound()
        {
           _sessionControllerMock.Setup(x => x.Delete(5, default)).Returns(() => null);
            var result = _controller.Delete(5, default);
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateSession_ShouldReturnValidModel_WhereModelWasFound()
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
    }
}