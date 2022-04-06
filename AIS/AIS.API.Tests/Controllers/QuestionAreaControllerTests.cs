using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AIS.API.Controllers;
using AIS.API.Tests.Models;
using AIS.API.Tests.ViewModels;
using AIS.API.ViewModels.QuestionArea;
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
        private readonly Mock<IQuestionAreaService> _serviceMock = new();

        [Fact]
        public async Task Add_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputQuestionAreaViewModel = ValidQuestionAreaViewModels.questionAreaAddViewModel;
            var inputQuestionAreaModel = ValidQuestionAreaModels.questionAreaModel;
            var expectedModel = ValidQuestionAreaViewModels.questionAreaViewModel;

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
            var inputQuestionAreaViewModel = ValidQuestionAreaViewModels.questionAreaUpdateViewModel;
            var inputQuestionAreaModel = ValidQuestionAreaModels.questionAreaModel;
            var expectedModel = ValidQuestionAreaViewModels.questionAreaViewModel;

            _mapperMock.Setup(map => map.Map<QuestionArea>(inputQuestionAreaViewModel)).Returns(inputQuestionAreaModel);
            _mapperMock.Setup(map => map.Map<QuestionAreaViewModel>(inputQuestionAreaModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Put(_mapperMock.Object.Map<QuestionArea>(inputQuestionAreaViewModel), default)).ReturnsAsync(inputQuestionAreaModel);

            var controller = new QuestionAreaController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.UpdateQuestionArea(default, inputQuestionAreaViewModel, default);

            // Assert
            inputQuestionAreaViewModel.Name.ShouldBeEquivalentTo(result.Name);
        }

        [Fact]
        public async Task Get_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            
            var id = new Random().Next();
            var expectedQuestionArea = ValidQuestionAreaModels.questionAreaModel;
            var expectedViewModel = ValidQuestionAreaViewModels.questionAreaViewModel;

            _mapperMock.Setup(map => map.Map<QuestionAreaViewModel>(expectedQuestionArea)).Returns(expectedViewModel);
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
            var expectedQuestionAreas = ValidQuestionAreaModels.questionAreasList;
            var expectedQuestionAreaViewModel = ValidQuestionAreaViewModels.questionAreasList;

            _mapperMock.Setup(map => map.Map<IEnumerable<ShortQuestionAreaViewModel>>(expectedQuestionAreas)).Returns(expectedQuestionAreaViewModel);
            _serviceMock.Setup(serv => serv.Get(default)).ReturnsAsync(expectedQuestionAreas);

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
            var expectedQuestionAreas = ValidQuestionAreaModels.deleteQuestionAreaModel;
            var expected = ValidQuestionAreaViewModels.deleteQuestionAreaViewModel;

            _mapperMock.Setup(map => map.Map<QuestionArea>(expected)).Returns(expectedQuestionAreas);
            _serviceMock.Setup(serv => serv.Delete(expectedQuestionAreas, default));

            var controller = new QuestionAreaController(_serviceMock.Object, _mapperMock.Object);

            // Act
            Action act = () => controller.DeleteQuestionArea(expected.Id, default);

            // Assert
            act.Should().NotThrow();
        }
    }
}
