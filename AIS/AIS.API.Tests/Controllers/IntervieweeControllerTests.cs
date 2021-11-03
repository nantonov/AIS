using AIS.API.Controllers;
using AIS.API.ViewModels.Interviewee;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Moq;
using Shouldly;
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
            var inputIntervieweeViewModel = new ChangeIntervieweeViewModel()
            {
                Name = "Boba",
                CompanyId = 3,
                AppliesFor = "asdasd"
            };
            var inputIntervieweeModel = new Interviewee()
            {
                Name = inputIntervieweeViewModel.Name,
                CompanyId = inputIntervieweeViewModel.CompanyId,
                AppliesFor = inputIntervieweeViewModel.AppliesFor
            };
            var expectedModel = new IntervieweeViewModel()
            {
                Name = inputIntervieweeViewModel.Name,
                CompanyId = inputIntervieweeViewModel.CompanyId,
                AppliesFor = inputIntervieweeModel.AppliesFor
            };

            _validatorMock.Setup(valid => valid.Validate(inputIntervieweeViewModel));
            _mapperMock.Setup(map => map.Map<Interviewee>(inputIntervieweeViewModel)).Returns(inputIntervieweeModel);
            _mapperMock.Setup(map => map.Map<IntervieweeViewModel>(inputIntervieweeModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Add(_mapperMock.Object.Map<Interviewee>(inputIntervieweeViewModel), default)).ReturnsAsync(inputIntervieweeModel);

            var controller = new IntervieweeController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.Post(inputIntervieweeViewModel, default);

            // Assert
            inputIntervieweeViewModel.Name.ShouldBeEquivalentTo(result.Name);
            inputIntervieweeViewModel.CompanyId.ShouldBeEquivalentTo(result.CompanyId);
        }

        [Fact]
        public async Task Update_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputIntervieweeViewModel = new ChangeIntervieweeViewModel()
            {
                Name = "Boba",
                CompanyId = 2
            };
            var inputIntervieweeModel = new Interviewee()
            {
                CompanyId = inputIntervieweeViewModel.CompanyId,
                Name = inputIntervieweeViewModel.Name
            };
            var expectedModel = new IntervieweeViewModel()
            {
                Name = inputIntervieweeModel.Name,
                CompanyId = inputIntervieweeModel.CompanyId
            };

            _validatorMock.Setup(valid => valid.Validate(inputIntervieweeViewModel));
            _mapperMock.Setup(map => map.Map<Interviewee>(inputIntervieweeViewModel)).Returns(inputIntervieweeModel);
            _mapperMock.Setup(map => map.Map<IntervieweeViewModel>(inputIntervieweeModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Put(_mapperMock.Object.Map<Interviewee>(inputIntervieweeViewModel), default)).ReturnsAsync(inputIntervieweeModel);

            var controller = new IntervieweeController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.Put(inputIntervieweeViewModel, 2, default);

            // Assert
            inputIntervieweeViewModel.CompanyId.ShouldBeEquivalentTo(result.CompanyId);
            inputIntervieweeViewModel.Name.ShouldBeEquivalentTo(result.Name);
        }

        [Fact]
        public async Task Get_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var expected = new[]
            {
                new ChangeIntervieweeViewModel
                {
                    Name = "Boba",
                    CompanyId = 1,
                    AppliesFor = "asdasd"
                },
                new ChangeIntervieweeViewModel
                {
                    Name = "Dida",
                    CompanyId = 2,
                    AppliesFor = "dsadsa"
                }
            };
            var expectedInterviewee = new[]
            {
                new Interviewee
                {
                    Name = expected[0].Name,
                    CompanyId = expected[0].CompanyId,
                    AppliesFor = expected[0].AppliesFor
                },
                new Interviewee
                {
                    Name = expected[1].Name,
                    CompanyId = expected[1].CompanyId,
                    AppliesFor = expected[1].AppliesFor
                }
            };
            var expectedIntervieweeViewModel = new[]
            {
                new ShortIntervieweeViewModel
                {
                    Name = expectedInterviewee[0].Name,
                    CompanyId = expectedInterviewee[0].CompanyId,
                    AppliesFor = expectedInterviewee[0].AppliesFor
                },
                new ShortIntervieweeViewModel
                {
                    Name = expectedInterviewee[1].Name,
                    CompanyId = expectedInterviewee[1].CompanyId,
                    AppliesFor = expectedInterviewee[1].AppliesFor
                }
            };

            _mapperMock.Setup(map => map.Map<IEnumerable<Interviewee>>(expected)).Returns(expectedInterviewee);
            _mapperMock.Setup(map => map.Map<IEnumerable<ShortIntervieweeViewModel>>(expectedInterviewee)).Returns(expectedIntervieweeViewModel);
            _serviceMock.Setup(serv => serv.Get(default)).ReturnsAsync(expectedInterviewee);

            var controller = new IntervieweeController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.GetInterviewees(default);

            // Assert
            expectedIntervieweeViewModel.ShouldBeEquivalentTo(result);
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
            var expectedInterviewee = new Interviewee()
            {
                Id = expected.Id,
                Name = expected.Name
            };

            _mapperMock.Setup(map => map.Map<Interviewee>(expected)).Returns(expectedInterviewee);
            _serviceMock.Setup(serv => serv.Delete(expectedInterviewee, default));

            var controller = new IntervieweeController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            Action act = () => controller.Delete(expected.Id, default);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public async Task GetIntervieweeById_ValidId_ShouldReturnValidInterviewee()
        {
            var expected = new IntervieweeViewModel()
            {
                Id = 3,
                Name = "Bob"
            };
            var expectedInterviewee = new Interviewee()
            {
                Id = expected.Id,
                Name = expected.Name
            };

            _serviceMock.Setup(x => x.GetById(expected.Id, default)).ReturnsAsync(expectedInterviewee);
            _mapperMock.Setup(x => x.Map<IntervieweeViewModel>(It.IsAny<Interviewee>())).Returns(expected);
            var controller = new IntervieweeController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);
            var result = await controller.GetInterviewee(expected.Id, default);
            _serviceMock.Verify(x => x.GetById(expected.Id, default), Times.Once);
            Assert.Equal(expectedInterviewee.Id, result.Id);
        }
    }
}
