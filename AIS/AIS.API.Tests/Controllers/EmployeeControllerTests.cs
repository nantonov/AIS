using AIS.API.Controllers;
using AIS.API.ViewModels;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AIS.API.Tests.Controllers
{
    public class EmployeeControllerTests
    {

        [Fact]
        public async Task Add_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var expected = new EmployeeViewModel()
            {
                Id = 1,
                Name = "Boba"
            };
            var expectedEmployee = new Employee()
            {
                Id = expected.Id,
                Name = expected.Name
            };

            var mockValidator = new Mock<IValidator<EmployeeViewModel>>();
            mockValidator.Setup(valid => valid.Validate(expected));
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(map => map.Map<Employee>(expected)).Returns(expectedEmployee);
            mockMapper.Setup(map => map.Map<EmployeeViewModel>(expectedEmployee)).Returns(expected);
            var mockService = new Mock<IGenericService<Employee>>();
            mockService.Setup(serv => serv.Add(mockMapper.Object.Map<Employee>(expected), default)).ReturnsAsync(expectedEmployee);
            var controller = new EmployeeController(mockMapper.Object, mockService.Object, mockValidator.Object);

            // Act
            var result = await controller.Add(expected, default);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Update_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var expected = new EmployeeViewModel()
            {
                Id = 1,
                Name = "Boba"
            };
            var expectedEmployee = new Employee()
            {
                Id = expected.Id,
                Name = expected.Name
            };

            var mockValidator = new Mock<IValidator<EmployeeViewModel>>();
            mockValidator.Setup(valid => valid.Validate(expected));
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(map => map.Map<Employee>(expected)).Returns(expectedEmployee);
            mockMapper.Setup(map => map.Map<EmployeeViewModel>(expectedEmployee)).Returns(expected);
            var mockService = new Mock<IGenericService<Employee>>();
            mockService.Setup(serv => serv.Put(mockMapper.Object.Map<Employee>(expected), default)).ReturnsAsync(expectedEmployee);
            var controller = new EmployeeController(mockMapper.Object, mockService.Object, mockValidator.Object);

            // Act
            var result = await controller.Update(expected, default);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Get_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var expected = new EmployeeViewModel[]
            {
                new EmployeeViewModel
                {
                    Id = 1,
                    Name = "Boba"
                },
                new EmployeeViewModel
                {
                    Id = 2,
                    Name = "Dida"
                }
            };
            var expectedEmployee = new Employee[]
            {
                new Employee
                {
                    Id = expected[0].Id,
                    Name = expected[0].Name
                },
                new Employee
                {
                    Id = expected[1].Id,
                    Name = expected[1].Name
                }
            };

            var mockValidator = new Mock<IValidator<EmployeeViewModel>>();
            mockValidator.Setup(valid => valid.Validate(null));
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(map => map.Map<IEnumerable<Employee>>(expected)).Returns(expectedEmployee);
            mockMapper.Setup(map => map.Map<IEnumerable<EmployeeViewModel>>(expectedEmployee)).Returns(expected);
            var mockService = new Mock<IGenericService<Employee>>();
            mockService.Setup(serv => serv.Get(default)).ReturnsAsync(expectedEmployee);
            var controller = new EmployeeController(mockMapper.Object, mockService.Object, mockValidator.Object);

            // Act
            var result = await controller.GetAll(default);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Delete_WhenContollerHasData_NoReturn()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var expected = new EmployeeViewModel()
            {
                Id = 3,
                Name = "Bob"
            };
            var expectedEmployee = new Employee()
            {
                Id = expected.Id,
                Name = expected.Name
            };

            var mockValidator = new Mock<IValidator<EmployeeViewModel>>();
            mockValidator.Setup(valid => valid.Validate(null));
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(map => map.Map<Employee>(expected)).Returns(expectedEmployee);
            var mockService = new Mock<IGenericService<Employee>>();
            mockService.Setup(serv => serv.Delete(expectedEmployee, default));
            var controller = new EmployeeController(mockMapper.Object, mockService.Object, mockValidator.Object);

            // Act
            Action act = () => controller.Delete(expected, default);

            // Assert
            act.Should().NotThrow();
        }
    }
}