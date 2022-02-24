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

namespace AIS.BLL.Tests.Services
{
    public class NextQuestionServiceTests
    {
        private readonly INextQuestionService _service;
        private readonly Mock<ISessionRepository> _sessionRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        public NextQuestionServiceTests()
        {
            _service = new NextQuestionService(_sessionRepoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Next_ValidData_ReturnsRandomQuestion()
        {
            int sessionId = 1;
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
            SessionEntity sessionEntity = new()
            {
                Id = sessionId,
                QuestionArea = new()
                {
                    QuestionSets = new List<QuestionSetEntity>()
                    {
                        new()
                        {
                            Id = 1,
                            Questions = questionsEntities
                        }
                    }
                },
                QuestionIntervieweeAnswers = questionIntervieweeAnswerEntities,

            };
            _sessionRepoMock.Setup(x => x.GetById(sessionId, default)).ReturnsAsync(sessionEntity);
            _mapperMock.Setup(x => x.Map<Question>(It.IsAny<QuestionEntity>())).Returns(question);

            var result = await _service.Next(sessionId, default);

            result.ShouldBe(question);
        }

        [Fact]
        public async Task Next_InvalidSession_ReturnsRandomQuestion()
        {
            int sessionId = -1000;
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
            _sessionRepoMock.Setup(x => x.GetById(sessionId, default)).ReturnsAsync(value: null);
            _mapperMock.Setup(x => x.Map<Question>(It.IsAny<QuestionEntity>())).Returns(question);

            var result = await _service.Next(sessionId, default);

            result.ShouldBeNull();
        }
    }
}
