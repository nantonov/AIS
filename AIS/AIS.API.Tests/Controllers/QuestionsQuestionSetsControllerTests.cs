using AIS.API.Controllers;
using AIS.API.Tests.Controllers.Models;
using AIS.API.Tests.Controllers.ViewModels;
using AIS.API.ViewModels.QuestionsQuestionSets;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using FluentValidation;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AIS.API.Tests.Controllers
{
    public class QuestionsQuestionSetsControllerTests
    {
        private readonly Mock<IValidator<ChangeQuestionsQuestionSetsViewModel>> _validatorMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IQuestionsQuestionSetsService> _serviceMock = new();

        [Fact]
        public async Task Add_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var questionsQuestionSetsViewModel = ValidQuestionsQuestionSetsViewModels.questionsQuestionSetsViewModelAdd;
            var questionsQuestionSetsModelWithId = ValidQuestionsQuestionSetsModels.questionsQuestionSetsViewModelAddWithId;
            var questionsQuestionSetsModel = ValidQuestionsQuestionSetsModels.questionsQuestionSetsViewModelAdd;
            var questionsQuestionSetsViewModelWithId = ValidQuestionsQuestionSetsViewModels.questionsQuestionSetsViewModelAddWithId;

            _validatorMock.Setup(valid => valid.Validate(questionsQuestionSetsViewModel));
            _mapperMock.Setup(map => map.Map<QuestionsQuestionSets>(questionsQuestionSetsViewModel)).Returns(questionsQuestionSetsModel);
            _mapperMock.Setup(map => map.Map<QuestionsQuestionSetsViewModel>(questionsQuestionSetsModelWithId)).Returns(questionsQuestionSetsViewModelWithId);
            _serviceMock.Setup(serv => serv.Add(It.IsAny<QuestionsQuestionSets>(), default)).ReturnsAsync(questionsQuestionSetsModelWithId);

            var controller = new QuestionsQuestionSetsController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.Post(questionsQuestionSetsViewModel, default);

            // Assert
            result.QuestionId.ShouldBe(1);
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task Update_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var id = 2;
            var questionsQuestionSetsViewModel = ValidQuestionsQuestionSetsViewModels.questionsQuestionSetsViewModelUpdate;
            var questionsQuestionSetsModelWithId = ValidQuestionsQuestionSetsModels.questionsQuestionSetsViewModelUpdateWithId;
            var questionsQuestionSetsModel = ValidQuestionsQuestionSetsModels.questionsQuestionSetsViewModelUpdate;
            var questionsQuestionSetsViewModelWithId = ValidQuestionsQuestionSetsViewModels.questionsQuestionSetsViewModelUpdateWithId;

            _validatorMock.Setup(valid => valid.Validate(questionsQuestionSetsViewModel));
            _mapperMock.Setup(map => map.Map<QuestionsQuestionSets>(questionsQuestionSetsViewModel)).Returns(questionsQuestionSetsModel);
            _mapperMock.Setup(map => map.Map<QuestionsQuestionSetsViewModel>(questionsQuestionSetsModelWithId)).Returns(questionsQuestionSetsViewModelWithId);
            _serviceMock.Setup(serv => serv.Put(It.IsAny<QuestionsQuestionSets>(), default)).ReturnsAsync(questionsQuestionSetsModelWithId);

            var controller = new QuestionsQuestionSetsController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.Put(questionsQuestionSetsViewModel, id, default);

            // Assert
            result.QuestionId.ShouldBe(1);
            result.Id.ShouldBe(id);
        }

        [Fact]
        public async Task Get_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var questionsQuestionSetsModels = ValidQuestionsQuestionSetsModels.questionsQuestionSetsModelsGet;
            var questionsQuestionSetsViewModels = ValidQuestionsQuestionSetsViewModels.questionsQuestionSetsViewModelsGet;


            _mapperMock.Setup(map => map.Map<IEnumerable<ShortQuestionsQuestionSetsViewModel>>(questionsQuestionSetsModels))
                .Returns(questionsQuestionSetsViewModels);
            _serviceMock.Setup(serv => serv.Get(default)).ReturnsAsync(questionsQuestionSetsModels);

            var controller = new QuestionsQuestionSetsController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.GetAll(default);

            // Assert
            result.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task GetById_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var id = 2;
            var questionsQuestionSetsModel = ValidQuestionsQuestionSetsModels.questionsQuestionSetsViewModelGetById;
            var questionsQuestionSetsViewModel = ValidQuestionsQuestionSetsViewModels.questionsQuestionSetsViewModelGetById;


            _mapperMock.Setup(map => map.Map<QuestionsQuestionSetsViewModel>(questionsQuestionSetsModel))
                .Returns(questionsQuestionSetsViewModel);
            _serviceMock.Setup(serv => serv.GetById(id, default)).ReturnsAsync(questionsQuestionSetsModel);

            var controller = new QuestionsQuestionSetsController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.GetById(id, default);

            // Assert
            result.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public void Delete_WhenContollerHasData_NoReturn()
        {
            // Arrange
            var id = 2;

            _serviceMock.Setup(serv => serv.Delete(id, default));

            var controller = new QuestionsQuestionSetsController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            Func<Task> act = async () => await controller.Delete(id, default);

            // Assert
            act.ShouldNotThrowAsync();
        }
    }
}
