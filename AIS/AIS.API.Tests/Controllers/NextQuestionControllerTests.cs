using AIS.API.Controllers;
using AIS.API.ViewModels.Question;
using AIS.BLL.Constants;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AIS.API.Tests.Controllers
{
    public class NextQuestionControllerTests
    {
        private readonly NextQuestionController _controller;
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<INextQuestionService> _serviceMock = new();
        public NextQuestionControllerTests()
        {
            _controller = new NextQuestionController(_serviceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task next_ValidData_ReturnsQuestion()
        {
            int set = 1;
            int session = 1;
            QuestionViewModel questionViewModel = new() { Id = 1, Text = "Some question 1"};
            Question question = new() { Id = 1, Text = "Some question 1" };

            _serviceMock.Setup(x => x.next(1, 1, default)).ReturnsAsync(question);
            _mapperMock.Setup(x => x.Map<QuestionViewModel>(question)).Returns(questionViewModel);

            var res = await _controller.next(session, set, default);

            res.ShouldBe(questionViewModel);
        }

        [Fact]
        public async Task next_InvalidSet_ReturnsEmptyQuestion()
        {
            int set = -10;
            int session = 1;
            QuestionViewModel emptyQuestionViewModel = new() { Id = -1000};
            Question question = EmptyQuestion.Empty;

            _serviceMock.Setup(x => x.next(1, 1, default)).ReturnsAsync(EmptyQuestion.Empty);
            _mapperMock.Setup(x => x.Map<QuestionViewModel>(question)).Returns(emptyQuestionViewModel);

            var res = await _controller.next(session, set, default);

            res.ShouldBe(emptyQuestionViewModel);
        }

        [Fact]
        public async Task next_InvalidSession_ReturnsEmptyQuestion()
        {
            int set = 1;
            int session = -100;
            QuestionViewModel questionViewModel = new() { Id = 1, Text = "Some question 1" };
            Question question = new() { Id = 1, Text = "Some question 1" };

            _serviceMock.Setup(x => x.next(1, 1, default)).ReturnsAsync(EmptyQuestion.Empty);
            _mapperMock.Setup(x => x.Map<QuestionViewModel>(question)).Returns(questionViewModel);

            var res = await _controller.next(session, set, default);

            res.ShouldBe(questionViewModel);
        }
    }
}
