using AIS.API.Controllers;
using AIS.API.ViewModels.Company;
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
    public class CompanyControllerTests
    {
        private readonly Mock<IValidator<ChangeCompanyViewModel>> _validatorMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IGenericService<Company>> _serviceMock = new();

        [Fact]
        public async Task Add_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputEmployeeViewModel = new ChangeCompanyViewModel()
            {
                Name = "Boba"
            };
            var inputEmployeeModel = new Company
            {
                Name = inputEmployeeViewModel.Name,
            };
            var expectedModel = new CompanyViewModel
            {
                Name = inputEmployeeViewModel.Name,
            };

            _validatorMock.Setup(valid => valid.Validate(inputEmployeeViewModel));
            _mapperMock.Setup(map => map.Map<Company>(inputEmployeeViewModel)).Returns(inputEmployeeModel);
            _mapperMock.Setup(map => map.Map<CompanyViewModel>(inputEmployeeModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Add(_mapperMock.Object.Map<Company>(inputEmployeeViewModel), default)).ReturnsAsync(inputEmployeeModel);

            var controller = new CompanyController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.Post(inputEmployeeViewModel, default);

            // Assert
            inputEmployeeViewModel.Name.ShouldBeEquivalentTo(result.Name);
        }

        [Fact]
        public async Task Update_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputEmployeeViewModel = new ChangeCompanyViewModel
            {
                Name = "Boba"
            };
            var inputEmployeeModel = new Company
            {
                Name = inputEmployeeViewModel.Name
            };
            var expectedModel = new CompanyViewModel
            {
                Name = inputEmployeeModel.Name
            };

            _validatorMock.Setup(valid => valid.Validate(inputEmployeeViewModel));
            _mapperMock.Setup(map => map.Map<Company>(inputEmployeeViewModel)).Returns(inputEmployeeModel);
            _mapperMock.Setup(map => map.Map<CompanyViewModel>(inputEmployeeModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Put(_mapperMock.Object.Map<Company>(inputEmployeeViewModel), default)).ReturnsAsync(inputEmployeeModel);

            var controller = new CompanyController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.Put(inputEmployeeViewModel, 2, default);

            // Assert
            inputEmployeeViewModel.Name.ShouldBeEquivalentTo(result.Name);
        }

        [Fact]
        public async Task Get_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var expected = new[]
            {
                new ChangeCompanyViewModel
                {
                    Name = "Boba"
                },
                new ChangeCompanyViewModel
                {
                    Name = "Dida"
                }
            };
            var expectedEmployee = new[]
            {
                new Company
                {
                    Name = expected[0].Name
                },
                new Company
                {
                    Name = expected[1].Name
                }
            };

            _mapperMock.Setup(map => map.Map<IEnumerable<Company>>(expected)).Returns(expectedEmployee);
            _mapperMock.Setup(map => map.Map<IEnumerable<ChangeCompanyViewModel>>(expectedEmployee)).Returns(expected);
            _serviceMock.Setup(serv => serv.Get(default)).ReturnsAsync(expectedEmployee);

            var controller = new CompanyController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.GetCompanies(default);

            // Assert
            expected.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public void Delete_WhenContollerHasData_NoReturn()
        {
            // Arrange
            var expected = new CompanyViewModel
            {
                Id = 3,
                Name = "Bob"
            };
            var expectedEmployee = new Company
            {
                Id = expected.Id,
                Name = expected.Name
            };

            _mapperMock.Setup(map => map.Map<Company>(expected)).Returns(expectedEmployee);
            _serviceMock.Setup(serv => serv.Delete(expectedEmployee, default));

            var controller = new CompanyController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            Action act = () => controller.Delete(expected.Id, default);

            // Assert
            act.Should().NotThrow();
        }
    }
}
