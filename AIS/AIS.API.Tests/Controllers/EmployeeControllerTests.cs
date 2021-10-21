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
using Shouldly;
using Xunit;

namespace AIS.API.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        private readonly Mock<IValidator<ChangeEmployeeViewModel>> _validatorMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IGenericService<Employee>> _serviceMock = new();

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

            _validatorMock.Setup(valid => valid.Validate(inputEmployeeViewModel));
            _mapperMock.Setup(map => map.Map<Employee>(inputEmployeeViewModel)).Returns(inputEmployeeModel);
            _mapperMock.Setup(map => map.Map<EmployeeViewModel>(inputEmployeeModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Add(_mapperMock.Object.Map<Employee>(inputEmployeeViewModel), default)).ReturnsAsync(inputEmployeeModel);

            var controller = new EmployeeController(_mapperMock.Object, _serviceMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.Add(inputEmployeeViewModel, default);

            // Assert
            inputEmployeeViewModel.Name.ShouldBeEquivalentTo(result.Name);
            inputEmployeeViewModel.CompanyId.ShouldBeEquivalentTo(result.CompanyId);
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

            _validatorMock.Setup(valid => valid.Validate(inputEmployeeViewModel));
            _mapperMock.Setup(map => map.Map<Employee>(inputEmployeeViewModel)).Returns(inputEmployeeModel);
            _mapperMock.Setup(map => map.Map<EmployeeViewModel>(inputEmployeeModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Put(_mapperMock.Object.Map<Employee>(inputEmployeeViewModel), default)).ReturnsAsync(inputEmployeeModel);

            var controller = new EmployeeController(_mapperMock.Object, _serviceMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.Update(inputEmployeeViewModel, 2, default);

            // Assert
            inputEmployeeViewModel.CompanyId.ShouldBeEquivalentTo(result.CompanyId);
            inputEmployeeViewModel.Name.ShouldBeEquivalentTo(result.Name);
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

            _mapperMock.Setup(map => map.Map<IEnumerable<Employee>>(expected)).Returns(expectedEmployee);
            _mapperMock.Setup(map => map.Map<IEnumerable<ChangeEmployeeViewModel>>(expectedEmployee)).Returns(expected);
            _serviceMock.Setup(serv => serv.Get(default)).ReturnsAsync(expectedEmployee);

            var controller = new EmployeeController(_mapperMock.Object, _serviceMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.GetAll(default);

            // Assert
            expected.ShouldBeEquivalentTo(result);
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

            _mapperMock.Setup(map => map.Map<Employee>(expected)).Returns(expectedEmployee);
            _serviceMock.Setup(serv => serv.Delete(expectedEmployee, default));

            var controller = new EmployeeController(_mapperMock.Object, _serviceMock.Object, _validatorMock.Object);

            // Act
            Action act = () => controller.Delete(expected.Id, default);

            // Assert
            act.Should().NotThrow();
        }
    }
}