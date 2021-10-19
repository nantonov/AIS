using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AIS.BLL.Tests.Business_Logic_Layer.Servuces
{
    public class SessionPositiveServiceTest
    {
        private readonly CancellationToken _ct = new();

        [Fact]
       public async Task GetSession_ShouldReturnListSession_WhereSessionExist()
       {
           // Arrange
           var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
           var expected = new[]
           {
               new Session() { Id = 3, StartTime = DateTime.Today, CompanyId = 5, EmployeeId = 5, IntervieweeId = 5, QuestionAreaId = 1},
               new Session() { Id = 4, StartTime = DateTime.Today, CompanyId = 5, EmployeeId = 5, IntervieweeId = 5, QuestionAreaId = 1 }
           };

           mocker.Setup<IGenericService<Session>, Task<IEnumerable<Session>>>(setup => setup.Get(CancellationToken.None)).ReturnsAsync(expected);

           var service = mocker.Get<IGenericService<Session>>();

           // Act
           var actual = await service.Get(CancellationToken.None);

           // Assert
           Assert.Equal(expected, actual);
       }
       [Fact]
       public async Task GetSessionById_ShouldReturnSession_WhereSessionWasFound()
       {
           // Arrange
           var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
           var expected = new Session()
           {
               Id = 5,
               StartTime = DateTime.Today,
               CompanyId = 5,
               EmployeeId = 5,
               IntervieweeId = 5,
               QuestionAreaId = 1
           };

           
           mocker.Setup<IGenericService<Session>, Task<Session>>(setup => setup.GetById(5, _ct)).ReturnsAsync(expected);

           var service = mocker.Get<IGenericService<Session>>();

           // Act
           var actual = await service.GetById(5, _ct);

           // Assert
           Assert.Equal(expected, actual);
       }
        [Fact]
       public async Task AddSession_ShouldReturnSession_WhereSessionValidModel()
       {
           // Arrange
           var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);

           var expected = new Session()
           {
               StartTime = DateTime.Today,
               CompanyId = 5,
               EmployeeId = 5,
               IntervieweeId = 5,
               QuestionAreaId = 1
           };


            mocker.Setup<IGenericService<Session>, Task<Session>>(setup => setup.Add(expected, CancellationToken.None)).ReturnsAsync(expected);

            var service = mocker.Get<IGenericService<Session>>();

           // Act
           var actual = await service.Add(expected, _ct);

           // Assert
           Assert.Equal(expected, actual);
       }

       [Fact]
       public async Task DeleteSession_ShouldNOtGenerateException_WhereModelWasFound()
       {
           var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);

           mocker.Setup<IGenericService<Session>, Task>(setup => setup.Delete(5, _ct));

           var service = mocker.Get<IGenericService<Employee>>();

           // Act
           Action act = () => service.Delete(5, _ct);

           // Assert
           act.Should().NotThrow();
       }

       [Fact]
       public async Task UpdateSession_ShouldReturnValidModel_WhereModelWasFound()
       {
           // Arrange
           var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
           var entity = new Session()
           {
               StartTime = DateTime.Today,
               CompanyId = 5,
               EmployeeId = 5,
               IntervieweeId = 5,
               QuestionAreaId = 1
           };

            mocker.Setup<IGenericService<Session>, Task<Session>>(setup => setup.Put(entity, _ct)).ReturnsAsync(entity);

           var service = mocker.Get<IGenericService<Session>>();

           // Act
           var actual = await service.Put(entity, CancellationToken.None);

           // Assert
           Assert.Equal(entity, actual);
       }
    }
}
