using AIS.API.Controllers;
using AIS.API.ViewModels.Employee;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AIS.API.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        private readonly Mock<IValidator<ChangeEmployeeViewModel>> _mockValidator = new();
        private readonly Mock<IMapper> _mockMapper = new();
        private readonly Mock<IGenericService<Employee>> _mockService = new();

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

            _mockValidator.Setup(valid => valid.Validate(inputEmployeeViewModel));
            _mockMapper.Setup(map => map.Map<Employee>(inputEmployeeViewModel)).Returns(inputEmployeeModel);
            _mockMapper.Setup(map => map.Map<EmployeeViewModel>(inputEmployeeModel)).Returns(expectedModel);
            _mockService.Setup(serv => serv.Add(_mockMapper.Object.Map<Employee>(inputEmployeeViewModel), default)).ReturnsAsync(inputEmployeeModel);

            var controller = new EmployeeController(_mockMapper.Object, _mockService.Object, _mockValidator.Object);

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

            _mockValidator.Setup(valid => valid.Validate(inputEmployeeViewModel));
            _mockMapper.Setup(map => map.Map<Employee>(inputEmployeeViewModel)).Returns(inputEmployeeModel);
            _mockMapper.Setup(map => map.Map<EmployeeViewModel>(inputEmployeeModel)).Returns(expectedModel);
            _mockService.Setup(serv => serv.Put(_mockMapper.Object.Map<Employee>(inputEmployeeViewModel), default)).ReturnsAsync(inputEmployeeModel);

            var controller = new EmployeeController(_mockMapper.Object, _mockService.Object, _mockValidator.Object);

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
            var expected = new[]
            {
                new ChangeEmployeeViewModel
                {
                    Name = "Boba"
                },
                new ChangeEmployeeViewModel
                {
                    Name = "Dida"
                }
            };
            var expectedEmployee = new[]
            {
                new Employee
                {
                    Name = expected[0].Name
                },
                new Employee
                {
                    Name = expected[1].Name
                }
            };

            _mockMapper.Setup(map => map.Map<IEnumerable<Employee>>(expected)).Returns(expectedEmployee);
            _mockMapper.Setup(map => map.Map<IEnumerable<ChangeEmployeeViewModel>>(expectedEmployee)).Returns(expected);
            _mockService.Setup(serv => serv.Get(default)).ReturnsAsync(expectedEmployee);

            var controller = new EmployeeController(_mockMapper.Object, _mockService.Object, _mockValidator.Object);

            // Act
            var result = await controller.GetAll(default);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Delete_WhenContollerHasData_NoReturn()
        {
            // Arrange
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

            _mockMapper.Setup(map => map.Map<Employee>(expected)).Returns(expectedEmployee);
            _mockService.Setup(serv => serv.Delete(expectedEmployee, default));

            var controller = new EmployeeController(_mockMapper.Object, _mockService.Object, _mockValidator.Object);

            // Act
            Action act = () => controller.Delete(expected.Id, default);

            // Assert
            act.Should().NotThrow();
        }
    }
}