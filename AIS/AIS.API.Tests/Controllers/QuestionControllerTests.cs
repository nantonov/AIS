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
    public class QuestionControllerTests
    {
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IGenericService<Question>> _serviceMock = new();

        [Fact]
        public async Task Add_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputQuestionViewModel = new QuestionViewModel()
            {
                Text = "Boba"
            };
            var inputQuestionModel = new Question
            {
                Text = inputQuestionViewModel.Text,
            };
            var expectedModel = new QuestionViewModel
            {
                Text = inputQuestionViewModel.Text,
            };

            _mapperMock.Setup(map => map.Map<Question>(inputQuestionViewModel)).Returns(inputQuestionModel);
            _mapperMock.Setup(map => map.Map<QuestionViewModel>(inputQuestionModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Add(_mapperMock.Object.Map<Question>(inputQuestionViewModel), default)).ReturnsAsync(inputQuestionModel);

            var controller = new QuestionsController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.AddQuestion(inputQuestionViewModel, default);

            // Assert
            inputQuestionViewModel.Text.ShouldBeEquivalentTo(result.Text);
        }

        [Fact]
        public async Task Update_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputQuestionViewModel = new QuestionViewModel
            {
                Text = "Boba"
            };
            var inputQuestionModel = new Question
            {
                Text = inputQuestionViewModel.Text
            };
            var expectedModel = new QuestionViewModel
            {
                Text = inputQuestionModel.Text
            };

            _mapperMock.Setup(map => map.Map<Question>(inputQuestionViewModel)).Returns(inputQuestionModel);
            _mapperMock.Setup(map => map.Map<QuestionViewModel>(inputQuestionModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Put(_mapperMock.Object.Map<Question>(inputQuestionViewModel), default)).ReturnsAsync(inputQuestionModel);

            var controller = new QuestionsController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.UpdateQuestion(inputQuestionViewModel, default);

            // Assert
            inputQuestionViewModel.Text.ShouldBeEquivalentTo(result.Text);
        }

        [Fact]
        public async Task Get_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange

            var id = new Random().Next();
            var expectedQuestion = new Question()
            {
                Id = id,
            };
            var expectedViewModel = new QuestionViewModel()
            {
                Id = id
            };

            _mapperMock.Setup(map => map.Map<Question, QuestionViewModel>(expectedQuestion)).Returns(expectedViewModel);
            _serviceMock.Setup(serv => serv.GetById(id, default)).ReturnsAsync(expectedQuestion);

            var controller = new QuestionsController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.GetQuestion(id, default);

            // Assert
            expectedViewModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task GetAll_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var expected = new[]
            {
                new QuestionViewModel()
                {
                    Text = "Boba"
                },
                new QuestionViewModel()
                {
                    Text = "Dida"
                }
            };
            var expectedQuestions = new[]
            {
                new Question
                {
                    Text = expected[0].Text
                },
                new Question
                {
                    Text = expected[1].Text
                }
            };
            var expectedQuestionViewModel = new[]
            {
                new QuestionViewModel
                {
                    Text = expected[0].Text
                },
                new QuestionViewModel
                {
                    Text = expected[0].Text
                }
            };

            _mapperMock.Setup(map => map.Map<IEnumerable<Question>>(expected)).Returns(expectedQuestions);
            _mapperMock.Setup(map => map.Map<IEnumerable<QuestionViewModel>>(expectedQuestions)).Returns(expectedQuestionViewModel);
            _serviceMock.Setup(serv => serv.Get(default)).ReturnsAsync(expectedQuestions);

            var controller = new QuestionsController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.GetQuestions(default);

            // Assert
            expectedQuestionViewModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public void Delete_WhenContollerHasData_NoReturn()
        {
            // Arrange
            var expected = new QuestionViewModel
            {
                Id = 3,
                Text = "Bob"
            };
            var expectedQuestions = new Question
            {
                Id = expected.Id,
                Text = expected.Text
            };

            _mapperMock.Setup(map => map.Map<Question>(expected)).Returns(expectedQuestions);
            _serviceMock.Setup(serv => serv.Delete(expectedQuestions, default));

            var controller = new QuestionsController(_serviceMock.Object, _mapperMock.Object);

            // Act
            Action act = () => controller.DeleteQuestion(expected.Id, default);

            // Assert
            act.Should().NotThrow();
        }
    }
}
