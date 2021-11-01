using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AIS.API.Controllers;
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
        private readonly Mock<IGenericService<QuestionSet>> _serviceMock = new();

        [Fact]
        public async Task Add_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputQuestionSetViewModel = new QuestionSetAddViewModel()
            {
                Name = "Boba"
            };
            var inputQuestionSetModel = new QuestionSet
            {
                Name = inputQuestionSetViewModel.Name,
            };
            var expectedModel = new QuestionSetViewModel
            {
                Name = inputQuestionSetViewModel.Name,
            };

            _mapperMock.Setup(map => map.Map<QuestionSet>(inputQuestionSetViewModel)).Returns(inputQuestionSetModel);
            _mapperMock.Setup(map => map.Map<QuestionSetViewModel>(inputQuestionSetModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Add(_mapperMock.Object.Map<QuestionSet>(inputQuestionSetViewModel), default)).ReturnsAsync(inputQuestionSetModel);

            var controller = new QuestionSetController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.AddQuestionSet(inputQuestionSetViewModel, default);

            // Assert
            inputQuestionSetViewModel.Name.ShouldBeEquivalentTo(result.Name);
        }

        [Fact]
        public async Task Update_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputQuestionSetViewModel = new QuestionSetUpdateViewModel
            {
                Name = "Boba"
            };
            var inputQuestionSetModel = new QuestionSet
            {
                Name = inputQuestionSetViewModel.Name
            };
            var expectedModel = new QuestionSetViewModel
            {
                Name = inputQuestionSetModel.Name
            };

            _mapperMock.Setup(map => map.Map<QuestionSet>(inputQuestionSetViewModel)).Returns(inputQuestionSetModel);
            _mapperMock.Setup(map => map.Map<QuestionSetViewModel>(inputQuestionSetModel)).Returns(expectedModel);
            _serviceMock.Setup(serv => serv.Put(_mapperMock.Object.Map<QuestionSet>(inputQuestionSetViewModel), default)).ReturnsAsync(inputQuestionSetModel);

            var controller = new QuestionSetController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.UpdateQuestionSet(default, inputQuestionSetViewModel, default);

            // Assert
            inputQuestionSetViewModel.Name.ShouldBeEquivalentTo(result.Name);
        }

        [Fact]
        public async Task Get_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange

            var id = new Random().Next();
            var expectedQuestionSet = new QuestionSet()
            {
                Id = id,
            };
            var expectedViewModel = new QuestionSetViewModel()
            {
                Id = id
            };

            _mapperMock.Setup(map => map.Map<QuestionSetViewModel>(expectedQuestionSet)).Returns(expectedViewModel);
            _serviceMock.Setup(serv => serv.GetById(id, default)).ReturnsAsync(expectedQuestionSet);

            var controller = new QuestionSetController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.GetQuestionSet(id, default);

            // Assert
            expectedViewModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task GetAll_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var expected = new[]
            {
                new QuestionSetViewModel()
                {
                    Name = "Boba"
                },
                new QuestionSetViewModel()
                {
                    Name = "Dida"
                }
            };
            var expectedQuestionSets = new[]
            {
                new QuestionSet
                {
                    Name = expected[0].Name
                },
                new QuestionSet
                {
                    Name = expected[1].Name
                }
            };
            var expectedQuestionSetViewModel = new[]
            {
                new QuestionSetViewModel
                {
                    Name = expected[0].Name
                },
                new QuestionSetViewModel
                {
                    Name = expected[0].Name
                }
            };

            _mapperMock.Setup(map => map.Map<IEnumerable<QuestionSet>>(expected)).Returns(expectedQuestionSets);
            _mapperMock.Setup(map => map.Map<IEnumerable<QuestionSetViewModel>>(expectedQuestionSets)).Returns(expectedQuestionSetViewModel);
            _serviceMock.Setup(serv => serv.Get(default)).ReturnsAsync(expectedQuestionSets);

            var controller = new QuestionSetController(_serviceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.GetQuestionSets(default);

            // Assert
            expectedQuestionSetViewModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public void Delete_WhenContollerHasData_NoReturn()
        {
            // Arrange
            var expected = new QuestionSetViewModel
            {
                Id = 3,
                Name = "Bob"
            };
            var expectedQuestionSets = new QuestionSet
            {
                Id = expected.Id,
                Name = expected.Name
            };

            _mapperMock.Setup(map => map.Map<QuestionSet>(expected)).Returns(expectedQuestionSets);
            _serviceMock.Setup(serv => serv.Delete(expectedQuestionSets, default));

            var controller = new QuestionSetController(_serviceMock.Object, _mapperMock.Object);

            // Act
            Action act = () => controller.DeleteQuestionSet(expected.Id, default);

            // Assert
            act.Should().NotThrow();
        }
    }
}
