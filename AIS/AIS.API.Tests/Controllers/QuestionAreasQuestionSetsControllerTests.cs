using AIS.API.Controllers;
using AIS.API.Tests.Controllers.Models;
using AIS.API.Tests.Controllers.ViewModels;
using AIS.API.ViewModels.QuestionAreasQuestionSets;
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
    public class QuestionAreasQuestionSetsControllerTests
    {
        private readonly Mock<IValidator<ChangeQuestionAreasQuestionSetsViewModel>> _validatorMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IQuestionAreasQuestionSetsService> _serviceMock = new();

        [Fact]
        public async Task Add_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var questionAreasQuestionSetsViewModel = ValidQuestionAreasQuestionSetsViewModels.questionAreasQuestionSetsViewModelAdd;
            var questionAreasQuestionSetsModel = ValidQuestionAreasQuestionSetsModels.questionAreasQuestionSetsModelAdd;
            var questionAreasQuestionSetsModelWithId = ValidQuestionAreasQuestionSetsModels.questionAreasQuestionSetsModelAddWithId;
            var questionAreasQuestionSetsViewModelWithId = ValidQuestionAreasQuestionSetsViewModels.questionAreasQuestionSetsViewModelAddWithId;

            _validatorMock.Setup(valid => valid.Validate(questionAreasQuestionSetsViewModel));
            _mapperMock.Setup(map => map.Map<QuestionAreasQuestionSets>(questionAreasQuestionSetsViewModel)).Returns(questionAreasQuestionSetsModel);
            _mapperMock.Setup(map => map.Map<QuestionAreasQuestionSetsViewModel>(questionAreasQuestionSetsModelWithId)).Returns(questionAreasQuestionSetsViewModelWithId);
            _serviceMock.Setup(serv => serv.Add(It.IsAny<QuestionAreasQuestionSets>(), default)).ReturnsAsync(questionAreasQuestionSetsModelWithId);

            var controller = new QuestionAreasQuestionSetsController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.Post(questionAreasQuestionSetsViewModel, default);

            // Assert
            result.QuestionAreaId.ShouldBe(1);
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task Update_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var id = 2;
            var questionAreasQuestionSetsViewModel = ValidQuestionAreasQuestionSetsViewModels.questionAreasQuestionSetsViewModelUpdate;
            var questionAreasQuestionSetsModel = ValidQuestionAreasQuestionSetsModels.questionAreasQuestionSetsModelUpdate;
            var questionAreasQuestionSetsModelWithId = ValidQuestionAreasQuestionSetsModels.questionAreasQuestionSetsModelUpdateWithId;
            var questionAreasQuestionSetsViewModelWithId = ValidQuestionAreasQuestionSetsViewModels.questionAreasQuestionSetsViewModelUpdateWithId;

            _validatorMock.Setup(valid => valid.Validate(questionAreasQuestionSetsViewModel));
            _mapperMock.Setup(map => map.Map<QuestionAreasQuestionSets>(questionAreasQuestionSetsViewModel)).Returns(questionAreasQuestionSetsModel);
            _mapperMock.Setup(map => map.Map<QuestionAreasQuestionSetsViewModel>(questionAreasQuestionSetsModelWithId)).Returns(questionAreasQuestionSetsViewModelWithId);
            _serviceMock.Setup(serv => serv.Put(It.IsAny<QuestionAreasQuestionSets>(), default)).ReturnsAsync(questionAreasQuestionSetsModelWithId);

            var controller = new QuestionAreasQuestionSetsController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.Put(questionAreasQuestionSetsViewModel, id, default);

            // Assert
            result.QuestionAreaId.ShouldBe(1);
            result.Id.ShouldBe(id);
        }

        [Fact]
        public async Task Get_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var questionAreasQuestionSetsModels = ValidQuestionAreasQuestionSetsModels.questionAreasQuestionSetsModelsGet;
            var questionAreasQuestionSetsViewModel = ValidQuestionAreasQuestionSetsViewModels.questionAreasQuestionSetsViewModelsGet;


            _mapperMock.Setup(map => map.Map<IEnumerable<ShortQuestionAreasQuestionSetsViewModel>>(questionAreasQuestionSetsModels))
                .Returns(questionAreasQuestionSetsViewModel);
            _serviceMock.Setup(serv => serv.Get(default)).ReturnsAsync(questionAreasQuestionSetsModels);

            var controller = new QuestionAreasQuestionSetsController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

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
            var questionAreasQuestionSets = ValidQuestionAreasQuestionSetsModels.questionAreasQuestionSetsModelGetById;
            var questionAreasQuestionSetsViewModel = ValidQuestionAreasQuestionSetsViewModels.questionAreasQuestionSetsViewModelGetById;


            _mapperMock.Setup(map => map.Map<QuestionAreasQuestionSetsViewModel>(questionAreasQuestionSets))
                .Returns(questionAreasQuestionSetsViewModel);
            _serviceMock.Setup(serv => serv.GetById(id, default)).ReturnsAsync(questionAreasQuestionSets);

            var controller = new QuestionAreasQuestionSetsController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

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

            var controller = new QuestionAreasQuestionSetsController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            Func<Task> act = async () => await controller.Delete(id, default);

            // Assert
            act.ShouldNotThrowAsync();
        }
    }
}
