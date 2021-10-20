using AIS.BLL.Interfaces.Services;
using AIS.BLL.Mapper;
using AIS.BLL.Mappers;
using AIS.BLL.Models;
using AIS.BLL.Services;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AIS.BLL.Tests.Business_Logic_Layer.Services
{
   public class GenericServiceTest
    {
        private readonly GenericService<Employee, EmployeeEntity> _service;
        private readonly Mock<IGenericRepository<EmployeeEntity>> _sessionRepoMock = new();

        public GenericServiceTest()
        {
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new EmployeeProfile()); });
            var mapper = mockMapper.CreateMapper();
            _service = new GenericService<Employee, EmployeeEntity>(_sessionRepoMock.Object, mapper);

        }

        [Fact]
        public async Task GetSessions_ReturnsEmptySessionList()
        {
            _sessionRepoMock.Setup(x => x.Get(default)).ReturnsAsync(() => null);
            var employees = await _service.Get(default);
            Assert.Equal(new List<Employee>(), employees);
        }

        [Fact]
        public async Task GetSession_NotValidId_ReturnsNull()
        {
            _sessionRepoMock.Setup(x => x.GetById(int.MaxValue, default)).ReturnsAsync(() => null);
            var session = await _service.GetById(int.MaxValue, default);
            Assert.Null(session);
        }

        [Fact]
        public async Task PutSession_ValidSession_ReturnsNull()
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
    }
}
