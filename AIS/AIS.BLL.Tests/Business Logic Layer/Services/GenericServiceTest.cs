using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.BLL.Services;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AIS.BLL.Tests.Business_Logic_Layer.Services
{
    public class GenericServiceTest
    {
        private readonly Mock<IGenericRepository<EmployeeEntity>> _sessionRepoMock = new();
        private readonly IGenericService<Employee> _service;
        private readonly Mock<IMapper> _mapperMock = new();

        public GenericServiceTest()
        {
            _service = new GenericService<Employee, EmployeeEntity>(_sessionRepoMock.Object, _mapperMock.Object);

        }

        [Fact]
        public async Task GetEmployee_ReturnsEmptyEmployeeList()
        {
            List<EmployeeEntity> employeesEntity = new()
            {
                new EmployeeEntity()
                {
                    Id = 5,
                    Name = "Test",
                    CompanyId = 5,
                }

            };
            List<Employee> employes = new()
            {
                new Employee()
                {
                    Id = 5,
                    Name = "Test",
                    CompanyId = 5,
                }
            };
            _mapperMock.Setup(x => x.Map<IEnumerable<EmployeeEntity>>(It.IsAny<IEnumerable<Employee>>()))
                .Returns(employeesEntity);
            _sessionRepoMock.Setup(x => x.Get(default)).ReturnsAsync(new List<EmployeeEntity>());
            _mapperMock.Setup(x => x.Map<IEnumerable<Employee>>(It.IsAny<IEnumerable<Session>>())).Returns(employes);
            var result = await _service.Get(default);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetEmployee_NotValidId_ReturnsNull()
        {
            _mapperMock.Setup(x => x.Map<EmployeeEntity>(It.IsAny<Employee>())).Returns(new EmployeeEntity());
            _sessionRepoMock.Setup(x => x.GetById(6, default)).ReturnsAsync(new EmployeeEntity());
            _mapperMock.Setup(x => x.Map<Employee>(It.IsAny<Session>())).Returns(new Employee());
            // Act
            var actual = await _service.GetById(int.MaxValue, default);

            // Assert
            Assert.NotEqual(int.MaxValue, actual.Id);
        }

        [Fact]
        public async Task PutEmployee_ValidEmployee_ReturnsEmployee()
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

            _mapperMock.Setup(x => x.Map<EmployeeEntity>(It.IsAny<Session>())).Returns(employeeEntity);
            _sessionRepoMock.Setup(x => x.Update(employeeEntity, default)).ReturnsAsync(() => employeeEntity);
            _mapperMock.Setup(x => x.Map<Employee>(It.IsAny<EmployeeEntity>())).Returns(employee);
            var expected = await _service.Put(employee, default);
            Assert.Equal(employee, expected);
        }

        [Fact]
        public async Task PostEmployee_ValidEmployee_ReturnsEmployee()
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
            _mapperMock.Setup(x => x.Map<EmployeeEntity>(It.IsAny<Employee>())).Returns(employeeEntity);
            _sessionRepoMock.Setup(x => x.Add(It.IsAny<EmployeeEntity>(), default)).ReturnsAsync(employeeEntity);
            _mapperMock.Setup(x => x.Map<Employee>(It.IsAny<EmployeeEntity>())).Returns(employee);
            // Act
            var actual = await _service.Add(employee, default);

            // Assert
            Assert.Equal(employee, actual);
        }

        [Fact]
        public void DeleteEmployee_ValidId_ReturnsNull()
        {
            _mapperMock.Setup(x => x.Map<EmployeeEntity>(It.IsAny<Employee>()));
            _service.Delete(6, default);
            _sessionRepoMock.Verify(x => x.Delete(6, default), Times.Once);
        }

        [Fact]
        public async Task GetSession_ReturnNull()
        {
            _sessionRepoMock.Setup(x => x.Get(default)).ReturnsAsync(It.IsAny<IEnumerable<EmployeeEntity>>());
            _mapperMock.Setup(x =>
                    x.Map<IEnumerable<EmployeeEntity>, IEnumerable<Employee>>(It.IsAny<IEnumerable<EmployeeEntity>>()))
                .Returns(new List<Employee>());

            await _service.Get(default);
            _sessionRepoMock.Verify(x => x.Get(default));
        }

        [Fact]
        public async Task DeleteEmployeeEntity_ValidId_ReturnsNull()
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
            _mapperMock.Setup(x => x.Map<EmployeeEntity>(It.IsAny<Employee>())).Returns(employeeEntity);
            await _service.Delete(employee, default);
            _mapperMock.Setup(x => x.Map<Employee>(It.IsAny<EmployeeEntity>())).Returns(employee);
            _sessionRepoMock.Verify(x => x.Delete(employeeEntity, default), Times.Once);
        }
    }
}