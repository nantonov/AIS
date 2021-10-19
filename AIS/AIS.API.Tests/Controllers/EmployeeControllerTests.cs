using AIS.API.Controllers;
using AIS.API.ViewModels.Employee;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
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
            var inputEmployeeViewModel = new ChangeEmployeeViewModel()
            {
                Name = "Boba",
                CompanyId = 3
            };
            var inputEmployeeModel = new Employee()
            {
                Name = inputEmployeeViewModel.Name,
                CompanyId = inputEmployeeViewModel.CompanyId
            };
            var expectedModel = new EmployeeViewModel()
            {
                Name = inputEmployeeViewModel.Name,
                CompanyId = inputEmployeeViewModel.CompanyId
            };

            var mockAddEmployeeValidator = new Mock<IValidator<ChangeEmployeeViewModel>>();
            mockAddEmployeeValidator.Setup(valid => valid.Validate(inputEmployeeViewModel));

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(map => map.Map<Employee>(inputEmployeeViewModel)).Returns(inputEmployeeModel);
            mockMapper.Setup(map => map.Map<EmployeeViewModel>(inputEmployeeModel)).Returns(expectedModel);

            var mockService = new Mock<IGenericService<Employee>>();
            mockService.Setup(serv => serv.Add(mockMapper.Object.Map<Employee>(inputEmployeeViewModel), default)).ReturnsAsync(inputEmployeeModel);

            var controller = new EmployeeController(mockMapper.Object, mockService.Object, mockAddEmployeeValidator.Object);

            // Act
            var result = await controller.Add(inputEmployeeViewModel, default);

            // Assert
            Assert.Equal(inputEmployeeViewModel.Name, result.Name);
            Assert.Equal(inputEmployeeViewModel.CompanyId, result.CompanyId);
        }

        [Fact]
        public async Task Update_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputEmployeeViewModel = new ChangeEmployeeViewModel()
            {
                Name = "Boba",
                CompanyId = 2
            };
            var inputEmployeeModel = new Employee()
            {
                CompanyId = inputEmployeeViewModel.CompanyId,
                Name = inputEmployeeViewModel.Name
            };
            var expectedModel = new EmployeeViewModel()
            {
                Name = inputEmployeeModel.Name,
                CompanyId = inputEmployeeModel.CompanyId
            };

            var mockValidator = new Mock<IValidator<ChangeEmployeeViewModel>>();
            mockValidator.Setup(valid => valid.Validate(inputEmployeeViewModel));

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(map => map.Map<Employee>(inputEmployeeViewModel)).Returns(inputEmployeeModel);
            mockMapper.Setup(map => map.Map<EmployeeViewModel>(inputEmployeeModel)).Returns(expectedModel);

            var mockService = new Mock<IGenericService<Employee>>();
            mockService.Setup(serv => serv.Put(mockMapper.Object.Map<Employee>(inputEmployeeViewModel), default)).ReturnsAsync(inputEmployeeModel);

            var controller = new EmployeeController(mockMapper.Object, mockService.Object, mockValidator.Object);

            // Act
            var result = await controller.Update(inputEmployeeViewModel, 2, default);

            // Assert
            Assert.Equal(inputEmployeeViewModel.CompanyId, result.CompanyId);
            Assert.Equal(inputEmployeeViewModel.Name, result.Name);
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

            var mockValidator = new Mock<IValidator<ChangeEmployeeViewModel>>();

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

            var mockValidator = new Mock<IValidator<ChangeEmployeeViewModel>>();

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(map => map.Map<Employee>(expected)).Returns(expectedEmployee);

            var mockService = new Mock<IGenericService<Employee>>();
            mockService.Setup(serv => serv.Delete(expectedEmployee, default));

            var controller = new EmployeeController(mockMapper.Object, mockService.Object, mockValidator.Object);

            // Act
            Action act = () => controller.Delete(expected.Id, default);

            // Assert
            act.Should().NotThrow();
        }
    }
}