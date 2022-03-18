using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using AIS.API.Controllers;
using AIS.API.Tests.Models;
using AIS.API.ViewModels.QuestionSet;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using FluentAssertions;
using Moq;
using Shouldly;
using Xunit;

namespace AIS.API.Tests.Controllers
{
    public class QuestionSetControllerTests
    {
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IQuestionSetService> _serviceMock = new();

        [Fact]
        public async Task Add_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var addQuestionSetViewModel = ValidQuestionSetModels.questionSetAddViewModel;
            var expectedQuestionSetModel = ValidQuestionSetModels.questionSetModel;
            var expectedQuestionSetViewModel = ValidQuestionSetModels.questionSetViewModel;

            _mapperMock.Setup(map => map.Map<QuestionSet>(addQuestionSetViewModel)).Returns(expectedQuestionSetModel);
            _mapperMock.Setup(map => map.Map<QuestionSetViewModel>(expectedQuestionSetModel)).Returns(expectedQuestionSetViewModel);
            _serviceMock.Setup(serv => serv.Add(_mapperMock.Object.Map<QuestionSet>(addQuestionSetViewModel), default))
                .ReturnsAsync(expectedQuestionSetModel);

            var controller = new QuestionSetController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.AddQuestionSet(addQuestionSetViewModel, default);

            // Assert
            addQuestionSetViewModel.Name.ShouldBeEquivalentTo(result.Name);
        }

        [Fact]
        public async Task Update_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange

            var updateQuestionSetViewModel = ValidQuestionSetModels.questionSetUpdateViewModel;
            var expectedQuestionSetViewModel = ValidQuestionSetModels.questionSetViewModel;
            var expectedQuestionSetModel = ValidQuestionSetModels.questionSetModel;


            _mapperMock.Setup(map => map.Map<QuestionSet>(updateQuestionSetViewModel)).Returns(expectedQuestionSetModel);
            _mapperMock.Setup(map => map.Map<QuestionSetViewModel>(expectedQuestionSetModel)).Returns(expectedQuestionSetViewModel);
            _serviceMock.Setup(serv => serv.Put(_mapperMock.Object.Map<QuestionSet>(updateQuestionSetViewModel), default)).ReturnsAsync(expectedQuestionSetModel);

            var controller = new QuestionSetController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.UpdateQuestionSet(default, updateQuestionSetViewModel, default);

            // Assert
            expectedQuestionSetViewModel.Name.ShouldBeEquivalentTo(result.Name);
        }

        [Fact]
        public async Task Get_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange

            var id = new Random().Next();
            var questionSetModel = ValidQuestionSetModels.questionSetModel;
            var expectedQuestionSetViewModel = ValidQuestionSetModels.questionSetViewModel;

            _mapperMock.Setup(map => map.Map<QuestionSetViewModel>(questionSetModel)).Returns(expectedQuestionSetViewModel);
            _serviceMock.Setup(serv => serv.GetById(id, default)).ReturnsAsync(questionSetModel);

            var controller = new QuestionSetController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.GetQuestionSet(id, default);

            // Assert
            expectedQuestionSetViewModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task GetAll_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var expectedQuestionSetShortViewModelList = ValidQuestionSetModels.questionSetEmptyShortList;

            var controller = new QuestionSetController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.GetQuestionSets(default);

            // Assert
            expectedQuestionSetShortViewModelList.ToImmutableList().ShouldBeEquivalentTo(result.ToImmutableList());
        }

        [Fact]
        public void Delete_WhenContollerHasData_NoReturn()
        {
            // Arrange
            var questionSetViewModel = ValidQuestionSetModels.questionSetViewModel;
            var expectedQuestionSetModel = ValidQuestionSetModels.questionSetModel;

            _mapperMock.Setup(map => map.Map<QuestionSet>(questionSetViewModel)).Returns(expectedQuestionSetModel);
            _serviceMock.Setup(serv => serv.Delete(expectedQuestionSetModel, default));

            var controller = new QuestionSetController(_serviceMock.Object, _mapperMock.Object);

            // Act
            Action act = () => controller.DeleteQuestionSet(questionSetViewModel.Id, default);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public async Task Add_WhenControllerHasDataAndQuestionAreaIdsAndQuestionIds_ShouldReturnValidModel()
        {
            // Arrange
            var addQuestionSetViewModel = ValidQuestionSetModels.questionSetAddViewModel;
            var questionSetModel = ValidQuestionSetModels.questionSetModel;
            var expectedModel = ValidQuestionSetModels.questionSetViewModel;

            _mapperMock.Setup(map => map.Map<QuestionSet>(addQuestionSetViewModel)).Returns(questionSetModel);
            _mapperMock.Setup(map => map.Map<QuestionSetViewModel>(questionSetModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Add(_mapperMock.Object.Map<QuestionSet>(addQuestionSetViewModel), default)).ReturnsAsync(questionSetModel);

            var controller = new QuestionSetController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.AddQuestionSet(addQuestionSetViewModel, default);

            // Assert
            expectedModel.Name.ShouldBeEquivalentTo(result.Name);
        }
    }
}
