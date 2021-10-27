using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AIS.API.Controllers;
using AIS.API.ViewModels;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using FluentAssertions;
using Moq;
using Shouldly;
using Xunit;

namespace AIS.API.Tests.Controllers
{
    public class QuestionAreaControllerTests
    {
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IGenericService<QuestionArea>> _serviceMock = new();

        [Fact]
        public async Task Add_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputQuestionAreaViewModel = new QuestionAreaViewModel()
            {
                Name = "Boba"
            };
            var inputQuestionAreaModel = new QuestionArea
            {
                Name = inputQuestionAreaViewModel.Name,
            };
            var expectedModel = new QuestionAreaViewModel
            {
                Name = inputQuestionAreaViewModel.Name,
            };

            _mapperMock.Setup(map => map.Map<QuestionArea>(inputQuestionAreaViewModel)).Returns(inputQuestionAreaModel);
            _mapperMock.Setup(map => map.Map<QuestionAreaViewModel>(inputQuestionAreaModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Add(_mapperMock.Object.Map<QuestionArea>(inputQuestionAreaViewModel), default)).ReturnsAsync(inputQuestionAreaModel);

            var controller = new QuestionAreaController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.AddQuestionArea(inputQuestionAreaViewModel, default);

            // Assert
            inputQuestionAreaViewModel.Name.ShouldBeEquivalentTo(result.Name);
        }

        [Fact]
        public async Task Update_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputQuestionAreaViewModel = new QuestionAreaViewModel
            {
                Name = "Boba"
            };
            var inputQuestionAreaModel = new QuestionArea
            {
                Name = inputQuestionAreaViewModel.Name
            };
            var expectedModel = new QuestionAreaViewModel
            {
                Name = inputQuestionAreaModel.Name
            };

            _mapperMock.Setup(map => map.Map<QuestionArea>(inputQuestionAreaViewModel)).Returns(inputQuestionAreaModel);
            _mapperMock.Setup(map => map.Map<QuestionAreaViewModel>(inputQuestionAreaModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Put(_mapperMock.Object.Map<QuestionArea>(inputQuestionAreaViewModel), default)).ReturnsAsync(inputQuestionAreaModel);

            var controller = new QuestionAreaController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.UpdateQuestionArea(inputQuestionAreaViewModel, default);

            // Assert
            inputQuestionAreaViewModel.Name.ShouldBeEquivalentTo(result.Name);
        }

        [Fact]
        public async Task Get_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            
            var id = new Random().Next();
            var expectedQuestionArea = new QuestionArea()
            {
                Id = id,
            };
            var expectedViewModel = new QuestionAreaViewModel()
            {
                Id = id
            };

            _mapperMock.Setup(map => map.Map<QuestionArea, QuestionAreaViewModel>(expectedQuestionArea)).Returns(expectedViewModel);
            _serviceMock.Setup(serv => serv.GetById(id, default)).ReturnsAsync(expectedQuestionArea);

            var controller = new QuestionAreaController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.GetQuestionArea(id, default);

            // Assert
            expectedViewModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task GetAll_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var expected = new[]
            {
                new QuestionAreaViewModel()
                {
                    Name = "Boba"
                },
                new QuestionAreaViewModel()
                {
                    Name = "Dida"
                }
            };
            var expectedCompanies = new[]
            {
                new QuestionArea
                {
                    Name = expected[0].Name
                },
                new QuestionArea
                {
                    Name = expected[1].Name
                }
            };
            var expectedQuestionAreaViewModel = new[]
            {
                new QuestionAreaViewModel
                {
                    Name = expected[0].Name
                },
                new QuestionAreaViewModel
                {
                    Name = expected[0].Name
                }
            };

            _mapperMock.Setup(map => map.Map<IEnumerable<QuestionArea>>(expected)).Returns(expectedCompanies);
            _mapperMock.Setup(map => map.Map<IEnumerable<QuestionAreaViewModel>>(expectedCompanies)).Returns(expectedQuestionAreaViewModel);
            _serviceMock.Setup(serv => serv.Get(default)).ReturnsAsync(expectedCompanies);

            var controller = new QuestionAreaController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.GetQuestionAreas(default);

            // Assert
            expectedQuestionAreaViewModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public void Delete_WhenContollerHasData_NoReturn()
        {
            // Arrange
            var expected = new QuestionAreaViewModel
            {
                Id = 3,
                Name = "Bob"
            };
            var expectedCompanies = new QuestionArea
            {
                Id = expected.Id,
                Name = expected.Name
            };

            _mapperMock.Setup(map => map.Map<QuestionArea>(expected)).Returns(expectedCompanies);
            _serviceMock.Setup(serv => serv.Delete(expectedCompanies, default));

            var controller = new QuestionAreaController(_serviceMock.Object, _mapperMock.Object);

            // Act
            Action act = () => controller.DeleteQuestionArea(expected.Id, default);

            // Assert
            act.Should().NotThrow();
        }
    }
}
