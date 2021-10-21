using AIS.API.Controllers;
using AIS.API.ViewModels.Interviewee;
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
    public class IntervieweeControllerTests
    {
        private readonly Mock<IValidator<ChangeIntervieweeViewModel>> _validatorMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IGenericService<Interviewee>> _serviceMock = new();

        [Fact]
        public async Task Add_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputEmployeeViewModel = new ChangeIntervieweeViewModel()
            {
                Name = "Boba",
                CompanyId = 3,
                AppliesFor = "asdasd"
            };
            var inputEmployeeModel = new Interviewee()
            {
                Name = inputEmployeeViewModel.Name,
                CompanyId = inputEmployeeViewModel.CompanyId,
                AppliesFor = inputEmployeeViewModel.AppliesFor
            };
            var expectedModel = new IntervieweeViewModel()
            {
                Name = inputEmployeeViewModel.Name,
                CompanyId = inputEmployeeViewModel.CompanyId,
                AppliesFor = inputEmployeeModel.AppliesFor
            };

            _validatorMock.Setup(valid => valid.Validate(inputEmployeeViewModel));
            _mapperMock.Setup(map => map.Map<Interviewee>(inputEmployeeViewModel)).Returns(inputEmployeeModel);
            _mapperMock.Setup(map => map.Map<IntervieweeViewModel>(inputEmployeeModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Add(_mapperMock.Object.Map<Interviewee>(inputEmployeeViewModel), default)).ReturnsAsync(inputEmployeeModel);

            var controller = new IntervieweeController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.Post(inputEmployeeViewModel, default);

            // Assert
            Assert.Equal(inputEmployeeViewModel.Name, result.Name);
            Assert.Equal(inputEmployeeViewModel.CompanyId, result.CompanyId);
        }

        [Fact]
        public async Task Update_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputEmployeeViewModel = new ChangeIntervieweeViewModel()
            {
                Name = "Boba",
                CompanyId = 2
            };
            var inputEmployeeModel = new Interviewee()
            {
                CompanyId = inputEmployeeViewModel.CompanyId,
                Name = inputEmployeeViewModel.Name
            };
            var expectedModel = new IntervieweeViewModel()
            {
                Name = inputEmployeeModel.Name,
                CompanyId = inputEmployeeModel.CompanyId
            };

            _validatorMock.Setup(valid => valid.Validate(inputEmployeeViewModel));
            _mapperMock.Setup(map => map.Map<Interviewee>(inputEmployeeViewModel)).Returns(inputEmployeeModel);
            _mapperMock.Setup(map => map.Map<IntervieweeViewModel>(inputEmployeeModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Put(_mapperMock.Object.Map<Interviewee>(inputEmployeeViewModel), default)).ReturnsAsync(inputEmployeeModel);

            var controller = new IntervieweeController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.Put(inputEmployeeViewModel, 2, default);

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
                new ChangeIntervieweeViewModel
                {
                    Name = "Boba"
                },
                new ChangeIntervieweeViewModel
                {
                    Name = "Dida"
                }
            };
            var expectedEmployee = new[]
            {
                new Interviewee
                {
                    Name = expected[0].Name
                },
                new Interviewee
                {
                    Name = expected[1].Name
                }
            };

            _mapperMock.Setup(map => map.Map<IEnumerable<Interviewee>>(expected)).Returns(expectedEmployee);
            _mapperMock.Setup(map => map.Map<IEnumerable<ChangeIntervieweeViewModel>>(expectedEmployee)).Returns(expected);
            _serviceMock.Setup(serv => serv.Get(default)).ReturnsAsync(expectedEmployee);

            var controller = new IntervieweeController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.GetInterviewees(default);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Delete_WhenContollerHasData_NoReturn()
        {
            // Arrange
            var expected = new IntervieweeViewModel()
            {
                Id = 3,
                Name = "Bob"
            };
            var expectedEmployee = new Interviewee()
            {
                Id = expected.Id,
                Name = expected.Name
            };

            _mapperMock.Setup(map => map.Map<Interviewee>(expected)).Returns(expectedEmployee);
            _serviceMock.Setup(serv => serv.Delete(expectedEmployee, default));

            var controller = new IntervieweeController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            Action act = () => controller.Delete(expected.Id, default);

            // Assert
            act.Should().NotThrow();
        }
    }
}
