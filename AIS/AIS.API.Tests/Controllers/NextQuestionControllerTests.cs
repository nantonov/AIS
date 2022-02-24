using AIS.API.Controllers;
using AIS.API.ViewModels.Question;
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
        public async Task Next_ValidData_ReturnsQuestion()
        {
            int session = 1;
            QuestionViewModel questionViewModel = new() { Id = 1, Text = "Some question 1"};
            Question question = new() { Id = 1, Text = "Some question 1" };

            _serviceMock.Setup(x => x.NextQuestion(session, default)).ReturnsAsync(question);
            _mapperMock.Setup(x => x.Map<QuestionViewModel>(question)).Returns(questionViewModel);

            var res = await _controller.NextQuestion(session, default);

            res.ShouldBe(questionViewModel);
        }

        [Fact]
        public async Task Next_InvalidSession_ReturnsRandomQuestion()
        {
            int session = -100;
            QuestionViewModel questionViewModel = new() { Id = 1, Text = "Some question 1" };
            Question question = new() { Id = 1, Text = "Some question 1" };

            _serviceMock.Setup(x => x.NextQuestion(session, default)).ReturnsAsync(question);
            _mapperMock.Setup(x => x.Map<QuestionViewModel>(question)).Returns(questionViewModel);

            var res = await _controller.NextQuestion(session, default);

            res.ShouldBe(questionViewModel);
        }
    }
}
