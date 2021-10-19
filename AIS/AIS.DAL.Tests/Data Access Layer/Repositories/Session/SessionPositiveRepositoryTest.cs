using System;
using System.Threading.Tasks;
using AIS.BLL.Mapper;
using AIS.BLL.Services;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AIS.DAL.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;

namespace AIS.DAL.Tests.Data_Access_Layer.Repositories.Session
{
    public class SessionPositiveRepositoryTest
    {
        private readonly Mock<DatabaseContext> _contextMock = new ();
        private readonly Mock<SessionRepository> _sessionRepoMock;
        private readonly Mock<IGenericRepository<SessionEntity>> _genericIRepoMock;

        public SessionPositiveRepositoryTest()
        {
            _sessionRepoMock = new Mock<SessionRepository>(_contextMock.Object);
        }

       // [Fact]
     /*   public async Task GetSession_ShouldReturnListSession_WhereSessionExist()
        {
            var expected = _genericIRepoMock.Setup(x => x.Get(default));
            Assert.NotNull(expected);
      //      _test.Setup(x => x.Get(default));
        }
     /*   [Fact]
        public async Task GetSessionById_ShouldReturnSession_WhereSessionWasFound()
        {
            const int sessionId = 5;
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
        public void DeleteSession_ShouldNOtGenerateException_WhereModelWasFound()
        {
            _sessionRepoMock.Setup(x => x.Delete(5, default)).Returns(() => null);
            var result = _service.Delete(5, default);
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
        }*/
    }
}
