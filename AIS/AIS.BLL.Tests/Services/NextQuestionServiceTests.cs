using System;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.BLL.Services;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using AIS.BLL.Constants;

namespace AIS.BLL.Tests.Services
{
    public class NextQuestionServiceTests
    {
        private readonly INextQuestionService _service;
        private readonly Mock<IGenericRepository<QuestionEntity>> _questionRepoMock = new();
        private readonly Mock<IGenericRepository<QuestionIntervieweeAnswerEntity>> _questionInterviewAnswerMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        public NextQuestionServiceTests()
        {
            _service = new NextQuestionService(_questionRepoMock.Object, _questionInterviewAnswerMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task next_ValidData_ReturnsRandomQuestion()
        {
            int set = 1;
            int session = 1;
            List<QuestionEntity> questionsEntities = new()
            {
                new()
                {
                    Id = 1,
                    QuestionSetId = 1,
                    Text = " some text 1"
                },
                new()
                {
                    Id = 2,
                    QuestionSetId = 1,
                    Text = " some text 2"
                }
            };
            Question question = new()
            {
                Id = 2,
                QuestionSetId = 1
            };
            List<QuestionIntervieweeAnswerEntity> questionIntervieweeAnswerEntities =
                new()
                {
                    new()
                    {
                        Id = 1,
                        QuestionId = 1,
                        Question = new()
                        {
                            Id = 1,
                            QuestionSetId = 1
                        },
                        SessionId = 1
                    }
                };

            _questionInterviewAnswerMock.Setup(x => x.Get(default)).ReturnsAsync(questionIntervieweeAnswerEntities);
            _questionRepoMock.Setup(x=> x.Get(default)).ReturnsAsync(questionsEntities);
            _mapperMock.Setup(x => x.Map<Question>(It.IsAny<QuestionEntity>())).Returns(question);

            var result = await _service.next(session, set, default);

            result.ShouldBe(question);
        }

        [Fact]
        public async Task next_InvalidSet_ReturnsEmptyQuestion()
        {
            int set = -100;
            int session = 1;

            List<QuestionEntity> questionsEntities = new()
            {
                new()
                {
                    Id = 1,
                    QuestionSetId = 1,
                    Text = " some text 1"
                },
                new()
                {
                    Id = 2,
                    QuestionSetId = 1,
                    Text = " some text 2"
                }
            };
            Question question = new()
            {
                Id = 2,
                QuestionSetId = 1
            };
            List<QuestionIntervieweeAnswerEntity> questionIntervieweeAnswerEntities =
                new()
                {
                    new()
                    {
                        Id = 1,
                        QuestionId = 1,
                        Question = new()
                        {
                            Id = 1,
                            QuestionSetId = 1
                        },
                        SessionId = 1
                    }
                };

            _questionInterviewAnswerMock.Setup(x => x.Get(default)).ReturnsAsync(questionIntervieweeAnswerEntities);
            _questionRepoMock.Setup(x => x.Get(default)).ReturnsAsync(questionsEntities);
            _mapperMock.Setup(x => x.Map<Question>(It.IsAny<QuestionEntity>())).Returns(question);

            var result = await _service.next(session, set, default);

            result.ShouldBe(EmptyQuestion.Empty);
        }

        [Fact]
        public async Task next_InvalidSession_ReturnsRandomQuestion()
        {
            int set = 1;
            int session = -1000;
            List<QuestionEntity> questionsEntities = new()
            {
                new()
                {
                    Id = 1,
                    QuestionSetId = 1,
                    Text = " some text 1"
                }
            };
            Question question = new()
            {
                Id = 2,
                QuestionSetId = 1
            };
            List<QuestionIntervieweeAnswerEntity> questionIntervieweeAnswerEntities =
                new()
                {
                    new()
                    {
                        Id = 1,
                        QuestionId = 1,
                        Question = new()
                        {
                            Id = 1,
                            QuestionSetId = 1
                        },
                        SessionId = 1
                    }
                };

            _questionInterviewAnswerMock.Setup(x => x.Get(default)).ReturnsAsync(questionIntervieweeAnswerEntities);
            _questionRepoMock.Setup(x => x.Get(default)).ReturnsAsync(questionsEntities);
            _mapperMock.Setup(x => x.Map<Question>(It.IsAny<QuestionEntity>())).Returns(question);

            var result = await _service.next(session, set, default);

            result.ShouldBe(question);
        }
    }
}
