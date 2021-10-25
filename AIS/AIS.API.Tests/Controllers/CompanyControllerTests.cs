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
            var inputCompanyViewModel = new ChangeCompanyViewModel()
            {
                Name = "Boba"
            };
            var inputCompanyModel = new Company
            {
                Name = inputCompanyViewModel.Name,
            };
            var expectedModel = new CompanyViewModel
            {
                Name = inputCompanyViewModel.Name,
            };

            _validatorMock.Setup(valid => valid.Validate(inputCompanyViewModel));
            _mapperMock.Setup(map => map.Map<Company>(inputCompanyViewModel)).Returns(inputCompanyModel);
            _mapperMock.Setup(map => map.Map<CompanyViewModel>(inputCompanyModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Add(_mapperMock.Object.Map<Company>(inputCompanyViewModel), default)).ReturnsAsync(inputCompanyModel);

            var controller = new CompanyController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.Post(inputCompanyViewModel, default);

            // Assert
            inputCompanyViewModel.Name.ShouldBeEquivalentTo(result.Name);
        }

        [Fact]
        public async Task Update_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputCompanyViewModel = new ChangeCompanyViewModel
            {
                Name = "Boba"
            };
            var inputCompanyModel = new Company
            {
                Name = inputCompanyViewModel.Name
            };
            var expectedModel = new CompanyViewModel
            {
                Name = inputCompanyModel.Name
            };

            _validatorMock.Setup(valid => valid.Validate(inputCompanyViewModel));
            _mapperMock.Setup(map => map.Map<Company>(inputCompanyViewModel)).Returns(inputCompanyModel);
            _mapperMock.Setup(map => map.Map<CompanyViewModel>(inputCompanyModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Put(_mapperMock.Object.Map<Company>(inputCompanyViewModel), default)).ReturnsAsync(inputCompanyModel);

            var controller = new CompanyController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.Put(inputCompanyViewModel, 2, default);

            // Assert
            inputCompanyViewModel.Name.ShouldBeEquivalentTo(result.Name);
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
            var expectedCompanies = new[]
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
            var expectedCompanyViewModel = new[]
            {
                new CompanyViewModel
                {
                    Name = expected[0].Name
                },
                new CompanyViewModel
                {
                    Name = expected[0].Name
                }
            };

            _mapperMock.Setup(map => map.Map<IEnumerable<Company>>(expected)).Returns(expectedCompanies);
            _mapperMock.Setup(map => map.Map<IEnumerable<CompanyViewModel>>(expectedCompanies)).Returns(expectedCompanyViewModel);
            _serviceMock.Setup(serv => serv.Get(default)).ReturnsAsync(expectedCompanies);

            var controller = new CompanyController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.GetCompanies(default);

            // Assert
            expectedCompanyViewModel.ShouldBeEquivalentTo(result);
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
            var expectedCompanies = new Company
            {
                Id = expected.Id,
                Name = expected.Name
            };

            _mapperMock.Setup(map => map.Map<Company>(expected)).Returns(expectedCompanies);
            _serviceMock.Setup(serv => serv.Delete(expectedCompanies, default));

            var controller = new CompanyController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            Action act = () => controller.Delete(expected.Id, default);

            // Assert
            act.Should().NotThrow();
        }
    }
}
