using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AIS.API.Controllers;
using AIS.API.ViewModels.TrueAnswer;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using FluentAssertions;
using Moq;
using Shouldly;
using Xunit;

namespace AIS.API.Tests.Controllers
{
    public class TrueAnswerControllerTests
    {
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IGenericService<TrueAnswer>> _serviceMock = new();

        [Fact]
        public async Task Add_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputTrueAnswerViewModel = new TrueAnswerAddViewModel()
            {
                Text = "Boba"
            };
            var inputTrueAnswerModel = new TrueAnswer
            {
                Text = inputTrueAnswerViewModel.Text,
            };
            var expectedModel = new TrueAnswerViewModel
            {
                Text = inputTrueAnswerViewModel.Text,
            };

            _mapperMock.Setup(map => map.Map<TrueAnswer>(inputTrueAnswerViewModel)).Returns(inputTrueAnswerModel);
            _mapperMock.Setup(map => map.Map<TrueAnswerViewModel>(inputTrueAnswerModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Add(_mapperMock.Object.Map<TrueAnswer>(inputTrueAnswerViewModel), default)).ReturnsAsync(inputTrueAnswerModel);

            var controller = new TrueAnswersController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.AddTrueAnswer(inputTrueAnswerViewModel, default);

            // Assert
            inputTrueAnswerViewModel.Text.ShouldBeEquivalentTo(result.Text);
        }

        [Fact]
        public async Task Update_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputTrueAnswerViewModel = new TrueAnswerUpdateViewModel
            {
                Text = "Boba"
            };
            var inputTrueAnswerModel = new TrueAnswer
            {
                Text = inputTrueAnswerViewModel.Text
            };
            var expectedModel = new TrueAnswerViewModel
            {
                Text = inputTrueAnswerModel.Text
            };

            _mapperMock.Setup(map => map.Map<TrueAnswer>(inputTrueAnswerViewModel)).Returns(inputTrueAnswerModel);
            _mapperMock.Setup(map => map.Map<TrueAnswerViewModel>(inputTrueAnswerModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Put(_mapperMock.Object.Map<TrueAnswer>(inputTrueAnswerViewModel), default)).ReturnsAsync(inputTrueAnswerModel);

            var controller = new TrueAnswersController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.UpdateTrueAnswer(inputTrueAnswerViewModel, default);

            // Assert
            inputTrueAnswerViewModel.Text.ShouldBeEquivalentTo(result.Text);
        }

        [Fact]
        public async Task Get_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange

            var id = new Random().Next();
            var expectedTrueAnswer = new TrueAnswer()
            {
                Id = id,
            };
            var expectedViewModel = new TrueAnswerViewModel()
            {
                Id = id
            };

            _mapperMock.Setup(map => map.Map<TrueAnswerViewModel>(expectedTrueAnswer)).Returns(expectedViewModel);
            _serviceMock.Setup(serv => serv.GetById(id, default)).ReturnsAsync(expectedTrueAnswer);

            var controller = new TrueAnswersController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.GetTrueAnswer(id, default);

            // Assert
            expectedViewModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task GetAll_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var expected = new[]
            {
                new TrueAnswerViewModel()
                {
                    Text = "Boba"
                },
                new TrueAnswerViewModel()
                {
                    Text = "Dida"
                }
            };
            var expectedTrueAnswers = new[]
            {
                new TrueAnswer
                {
                    Text = expected[0].Text
                },
                new TrueAnswer
                {
                    Text = expected[1].Text
                }
            };
            var expectedTrueAnswerViewModel = new[]
            {
                new TrueAnswerViewModel
                {
                    Text = expected[0].Text
                },
                new TrueAnswerViewModel
                {
                    Text = expected[0].Text
                }
            };

            _mapperMock.Setup(map => map.Map<IEnumerable<TrueAnswer>>(expected)).Returns(expectedTrueAnswers);
            _mapperMock.Setup(map => map.Map<IEnumerable<TrueAnswerViewModel>>(expectedTrueAnswers)).Returns(expectedTrueAnswerViewModel);
            _serviceMock.Setup(serv => serv.Get(default)).ReturnsAsync(expectedTrueAnswers);

            var controller = new TrueAnswersController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.GetTrueAnswers(default);

            // Assert
            expectedTrueAnswerViewModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public void Delete_WhenContollerHasData_NoReturn()
        {
            // Arrange
            var expected = new TrueAnswerViewModel
            {
                Id = 3,
                Text = "Bob"
            };
            var expectedTrueAnswers = new TrueAnswer
            {
                Id = expected.Id,
                Text = expected.Text
            };

            _mapperMock.Setup(map => map.Map<TrueAnswer>(expected)).Returns(expectedTrueAnswers);
            _serviceMock.Setup(serv => serv.Delete(expectedTrueAnswers, default));

            var controller = new TrueAnswersController(_serviceMock.Object, _mapperMock.Object);

            // Act
            Action act = () => controller.DeleteTrueAnswer(expected.Id, default);

            // Assert
            act.Should().NotThrow();
        }
    }
}
