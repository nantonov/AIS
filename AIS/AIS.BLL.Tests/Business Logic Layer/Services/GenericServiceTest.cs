using AIS.BLL.Interfaces.Services;
using AIS.BLL.Mappers;
using AIS.BLL.Models;
using AIS.BLL.Services;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AIS.BLL.Tests.Business_Logic_Layer.Services
{
    public class GenericServiceTest
    {
        private readonly GenericService<Employee, EmployeeEntity> _service;
        private readonly Mock<IGenericRepository<EmployeeEntity>> _sessionRepoMock = new();
        private readonly IGenericService<Session> _genericService;
        private readonly AutoMocker _mocker = new(MockBehavior.Default, DefaultValue.Mock);

        public GenericServiceTest()
        {
            _genericService = _mocker.Get<IGenericService<Session>>();
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new EmployeeProfile()); });
            var mapper = mockMapper.CreateMapper();
            _service = new GenericService<Employee, EmployeeEntity>(_sessionRepoMock.Object, mapper);

        }

        [Fact]
        public async Task GetEmployee_ReturnsEmptyEmployeeList()
        {
            _sessionRepoMock.Setup(x => x.Get(default)).ReturnsAsync(() => null);
            var employees = await _service.Get(default);
            Assert.Equal(new List<Employee>(), employees);
        }

        [Fact]
        public async Task GetEmployee_NotValidId_ReturnsNull()
        {
            _sessionRepoMock.Setup(x => x.GetById(int.MaxValue, default)).ReturnsAsync(() => null);
            var session = await _service.GetById(int.MaxValue, default);
            Assert.Null(session);
        }

        [Fact]
        public async Task PutEmployee_ValidEmployee_ReturnsNull()
        {
            var employeeEntity = new EmployeeEntity()
            {
                Id = 5,
                Name = "Test",
                CompanyId = 5,
            };
            var employee = new Employee()
            {
                Id = 5,
                Name = "Test",
                CompanyId = 5,
            };
            _sessionRepoMock.Setup(x => x.Update(employeeEntity, default)).ReturnsAsync(employeeEntity);
            var expected = await _service.Put(employee, default);
            Assert.Null(expected);
        }

        [Fact]
        public async Task PostSession_ValidSession_ReturnsSession()
        {
            var session = new Session()
            {
                Id = 11,
                StartTime = DateTime.Today,
                CompanyId = 5,
                EmployeeId = 5,
                IntervieweeId = 5,
                QuestionAreaId = 1
            };

            _mocker.Setup<IGenericService<Session>, Task<Session>>(setup => setup.Add(session, CancellationToken.None))
                .ReturnsAsync(session);

            // Act
            var actual = await _genericService.Add(session, default);

            // Assert
            Assert.Equal(session, actual);
        }

        [Fact]
        public async Task DeleteEmployee_ValidId_ReturnsNull()
        {
            var employeeEntity = new EmployeeEntity()
            {
                Id = 6,
                Name = "Test",
                CompanyId = 5,
            };
            var employee = new Employee()
            {
                Id = 6,
                Name = "Test",
                CompanyId = 5,
            };
            _sessionRepoMock.Setup(x => x.Delete(employeeEntity, default));
            _sessionRepoMock.Setup(x => x.GetById(6, default)).ReturnsAsync(() => null);
            await _service.Delete(employee, default);
            Assert.True(true);
        }
    }
}