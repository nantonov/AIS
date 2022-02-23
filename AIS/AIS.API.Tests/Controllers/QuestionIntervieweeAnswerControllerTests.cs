using AIS.API.Controllers;
using AIS.API.ViewModels.QuestionIntervieweeAnswer;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using FluentAssertions;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AIS.API.Tests.Controllers
{
    public class QuestionIntervieweeAnswerControllerTests
    {
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IGenericService<QuestionIntervieweeAnswer>> _serviceMock = new();

        [Fact]
        public async Task Add_ControllerHasData_ReturnsValidModel()
        {
            // Arrange
            var inputViewModel = new QuestionIntervieweeAnswerAddViewModel()
            {
                QuestionId = 1,
                Mark = 1,
                Text = "qwe"
            };
            var inputModel = new QuestionIntervieweeAnswer
            {
                QuestionId = inputViewModel.QuestionId,
                Mark = inputViewModel.Mark,
                Text = inputViewModel.Text
            };

            _mapperMock.Setup(map => map.Map<QuestionIntervieweeAnswer>(inputViewModel)).Returns(inputModel);
            _mapperMock.Setup(map => map.Map<QuestionIntervieweeAnswerAddViewModel>(inputModel)).Returns(inputViewModel);
            _serviceMock.Setup(serv => serv.Add(_mapperMock.Object.Map<QuestionIntervieweeAnswer>(inputViewModel), default)).ReturnsAsync(inputModel);

            var controller = new QuestionIntervieweeAnswerController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.Add(inputViewModel, default);

            // Assert
            inputViewModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Update_ControllerHasData_ReturnsValidModel()
        {
            // Arrange
            var inputViewModel = new QuestionIntervieweeAnswerUpdateViewModel()
            {
                QuestionId = 1,
                Mark = 1,
                Text = "qwe"
            };
            var inputModel = new QuestionIntervieweeAnswer
            {
                QuestionId = inputViewModel.QuestionId,
                Mark = inputViewModel.Mark,
                Text = inputViewModel.Text
            };
            var expected = new QuestionIntervieweeAnswerViewModel()
            {
                QuestionId = inputViewModel.QuestionId,
                Mark = inputViewModel.Mark,
                Text = inputViewModel.Text
            };

            _mapperMock.Setup(map => map.Map<QuestionIntervieweeAnswer>(inputViewModel)).Returns(inputModel);
            //_mapperMock.Setup(map => map.Map<QuestionIntervieweeAnswerUpdateViewModel>(inputModel)).Returns(inputViewModel);
            _mapperMock.Setup(map => map.Map<QuestionIntervieweeAnswerViewModel>(inputModel)).Returns(expected);
            _serviceMock.Setup(serv => serv.Put(_mapperMock.Object.Map<QuestionIntervieweeAnswer>(inputViewModel), default)).ReturnsAsync(inputModel);

            var controller = new QuestionIntervieweeAnswerController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.Update(inputViewModel, default, default);

            // Assert
            result.ShouldBeEquivalentTo(expected);
        }

        [Fact]
        public async Task Get_ControllerHasData_ReturnsValidModel()
        {
            // Arrange
            var id = new Random().Next();
            var expectedQuestionIntervieweeAnswer = new QuestionIntervieweeAnswer()
            {
                Id = id,
            };
            var expectedViewModel = new QuestionIntervieweeAnswerViewModel()
            {
                Id = id
            };

            _mapperMock.Setup(map => map.Map<QuestionIntervieweeAnswerViewModel>(expectedQuestionIntervieweeAnswer)).Returns(expectedViewModel);
            _serviceMock.Setup(serv => serv.GetById(id, default)).ReturnsAsync(expectedQuestionIntervieweeAnswer);

            var controller = new QuestionIntervieweeAnswerController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.GetById(id, default);

            // Assert
            expectedViewModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task GetAll_ControllerHasData_ReturnsValidModel()
        {
            // Arrange
            var inputViewModel = new[]
            {
                new QuestionIntervieweeAnswerViewModel()
                {
                    QuestionId = 1,
                    Mark = 1,
                    Text = "qwe"
                },
                new QuestionIntervieweeAnswerViewModel()
                {
                    QuestionId = 1,
                    Mark = 1,
                    Text = "qwe"
                }
            };
            var inputModel = new[]
            {
                new QuestionIntervieweeAnswer
                {
                    QuestionId = inputViewModel[0].QuestionId,
                    Mark = inputViewModel[0].Mark,
                    Text = inputViewModel[0].Text
                },
                new QuestionIntervieweeAnswer
                {
                    QuestionId = inputViewModel[1].QuestionId,
                    Mark = inputViewModel[1].Mark,
                    Text = inputViewModel[1].Text
                }
            };
            var expected = new[]
            {
                new ShortQuestionIntervieweeAnswerViewModel
                {
                    QuestionId = inputViewModel[0].QuestionId,
                    Mark = inputViewModel[0].Mark,
                    Text = inputViewModel[0].Text
                },
                new ShortQuestionIntervieweeAnswerViewModel
                {
                    QuestionId = inputViewModel[1].QuestionId,
                    Mark = inputViewModel[1].Mark,
                    Text = inputViewModel[1].Text
                }
            };

            _mapperMock.Setup(map => map.Map<IEnumerable<QuestionIntervieweeAnswer>>(expected)).Returns(inputModel);
            _mapperMock.Setup(map => map.Map<IEnumerable<ShortQuestionIntervieweeAnswerViewModel>>(inputModel)).Returns(expected);
            _serviceMock.Setup(serv => serv.Get(default)).ReturnsAsync(inputModel);

            var controller = new QuestionIntervieweeAnswerController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.GetAll(default);

            // Assert
            expected.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public void Delete_WhenContollerHasData_NoReturn()
        {
            // Arrange
            var expected = new QuestionIntervieweeAnswerViewModel
            {
                Id = 3
            };
            var expectedQuestionIntervieweeAnswers = new QuestionIntervieweeAnswer
            {
                Id = expected.Id
            };

            _mapperMock.Setup(map => map.Map<QuestionIntervieweeAnswer>(expected)).Returns(expectedQuestionIntervieweeAnswers);
            _serviceMock.Setup(serv => serv.Delete(expectedQuestionIntervieweeAnswers, default));

            var controller = new QuestionIntervieweeAnswerController(_serviceMock.Object, _mapperMock.Object);

            // Act
            Action act = () => controller.Delete(expected.Id, default);

            // Assert
            act.Should().NotThrow();
        }
    }
}
