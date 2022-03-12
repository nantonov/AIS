using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.BLL.Services;
using AIS.BLL.Tests.Entities;
using AIS.BLL.Tests.Models;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace AIS.BLL.Tests.Services
{
    public class QuestionsQuestionSetsServiceTests
    {
        private readonly IQuestionsQuestionSetsService _service;
        private readonly Mock<IQuestionsQuestionSetsRepository> _repoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        public QuestionsQuestionSetsServiceTests()
        {
            _service = new QuestionsQuestionSetsService(_repoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetQuestionsQuestionSets_HasData_ReturnQuestionsQuestionSetsList()
        {
            var questionsQuestionSetsEntities = ValidQuestionsQuestionSetsEntities.questionsQuestionSetsEntitiesGet;
            var questionsQuestionSetsModels = ValidQuestionsQuestionSetsModels.questionsQuestionSetsModelsGet;

            _mapperMock.Setup(x => x.Map<IEnumerable<QuestionsQuestionSets>>(It.IsAny<IEnumerable<QuestionsQuestionSetsEntity>>()))
                .Returns(questionsQuestionSetsModels);
            _repoMock.Setup(x => x.Get(default)).ReturnsAsync(questionsQuestionSetsEntities);
            var result = await _service.Get(default);
            Assert.NotNull(result);
            Assert.Equal(questionsQuestionSetsModels.Count, result.Count());
            result.ShouldBeEquivalentTo(questionsQuestionSetsModels);
        }

        [Fact]
        public async Task GetQuestionsQuestionSets_HasNotData_ReturnQuestionsQuestionSetsList()
        {
            List<QuestionsQuestionSetsEntity> questionsQuestionSetsEntities = new();
            List<QuestionsQuestionSets> questionsQuestionSetsModels = new();
            _repoMock.Setup(x => x.Get(default)).ReturnsAsync(questionsQuestionSetsEntities);
            _mapperMock.Setup(x => x.Map<IEnumerable<QuestionsQuestionSets>>(It.IsAny<IEnumerable<QuestionsQuestionSetsEntity>>())).Returns(questionsQuestionSetsModels);
            var result = await _service.Get(default);
            Assert.Equal(new List<QuestionsQuestionSets>(), result);
        }

        [Fact]
        public async Task GetQuestionsQuestionSetsById_ValidId_ReturnsQuestionsQuestionSetsById()
        {
            var questionsQuestionSetsEntity = ValidQuestionsQuestionSetsEntities.questionsQuestionSetsEntityGetById;
            var questionsQuestionSets = ValidQuestionsQuestionSetsModels.questionsQuestionSetsModelGetById;

            _repoMock.Setup(x => x.GetById(6, default)).ReturnsAsync(questionsQuestionSetsEntity);
            _mapperMock.Setup(x => x.Map<QuestionsQuestionSets>(It.IsAny<QuestionsQuestionSetsEntity>())).Returns(questionsQuestionSets);
            // Act
            var actual = await _service.GetById(questionsQuestionSets.Id, default);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(questionsQuestionSets.Id, actual.Id);
        }

        [Fact]
        public async Task GetQuestionsQuestionSetsById_InvalidId_ReturnsNullQuestionsQuestionSetsById()
        {
            QuestionsQuestionSetsEntity questionsQuestionSetsEntity = null;
            QuestionsQuestionSets questionsQuestionSets = null;

            _repoMock.Setup(x => x.GetById(int.MaxValue, default)).ReturnsAsync(questionsQuestionSetsEntity);
            _mapperMock.Setup(x => x.Map<QuestionsQuestionSets>(It.IsAny<QuestionsQuestionSetsEntity>()))
                .Returns(questionsQuestionSets);

            // Act
            var actual = await _service.GetById(int.MaxValue, default);

            // Assert
            Assert.Null(actual);
        }

        [Fact]
        public async Task DeleteQuestionsQuestionSets_ValidId_ReturnsNull()
        {
            _repoMock.Setup(x => x.Delete(int.MaxValue, default));

            await _service.Delete(20, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task DeleteQuestionsQuestionSets_ValidQuestionsQuestionSets_ReturnsNull()
        {
            var questionsQuestionSetsEntity = ValidQuestionsQuestionSetsEntities.questionsQuestionSetsEntityDelete;
            var questionsQuestionSets = ValidQuestionsQuestionSetsModels.questionsQuestionSetsModelDelete;

            _mapperMock.Setup(x => x.Map<QuestionsQuestionSetsEntity>(It.IsAny<QuestionsQuestionSets>()))
                .Returns(questionsQuestionSetsEntity);
            _repoMock.Setup(x => x.Delete(questionsQuestionSetsEntity, default));

            await _service.Delete(questionsQuestionSets, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task PutQuestionsQuestionSets_ValidQuestionsQuestionSets_ReturnsQuestionsQuestionSets()
        {
            var questionsQuestionSetsEntity = ValidQuestionsQuestionSetsEntities.questionsQuestionSetsEntityPut;
            var questionsQuestionSets = ValidQuestionsQuestionSetsModels.questionsQuestionSetsModelPut;

            _mapperMock.Setup(x => x.Map<QuestionsQuestionSetsEntity>(It.IsAny<QuestionsQuestionSets>()))
                .Returns(questionsQuestionSetsEntity);
            _repoMock.Setup(x => x.Update(questionsQuestionSetsEntity, default)).ReturnsAsync(() => questionsQuestionSetsEntity);
            _mapperMock.Setup(x => x.Map<QuestionsQuestionSets>(It.IsAny<QuestionsQuestionSetsEntity>()))
                .Returns(questionsQuestionSets);
            var expected = await _service.Put(questionsQuestionSets, default);
            Assert.NotNull(expected);
            Assert.Equal(questionsQuestionSets, expected);
        }

        [Fact]
        public async Task PutQuestionsQuestionSets_InvalidQuestionsQuestionSets_ReturnsNull()
        {
            var questionsQuestionSetsEntity = (QuestionsQuestionSetsEntity)null;

            _mapperMock.Setup(x => x.Map<QuestionsQuestionSetsEntity>(It.IsAny<QuestionsQuestionSets>())).Returns((QuestionsQuestionSetsEntity)null);
            _repoMock.Setup(x => x.Update(questionsQuestionSetsEntity, default)).ReturnsAsync((QuestionsQuestionSetsEntity)null);
            _mapperMock.Setup(x => x.Map<QuestionsQuestionSets>(It.IsAny<QuestionsQuestionSetsEntity>())).Returns((QuestionsQuestionSets)null);
            var result = await _service.Put(null, default);
            Assert.Null(result);
        }

        [Fact]
        public async Task AddQuestionsQuestionSets_ValidQuestionsQuestionSets_ReturnsQuestionsQuestionSets()
        {
            var questionsQuestionSetsEntity = ValidQuestionsQuestionSetsEntities.questionsQuestionSetsEntityAdd;
            var questionsQuestionSets = ValidQuestionsQuestionSetsModels.questionsQuestionSetsModelAdd;
            var questionsQuestionSetsEntityWithId = ValidQuestionsQuestionSetsEntities.questionsQuestionSetsEntityAdd;
            var questionsQuestionSetsWithId = ValidQuestionsQuestionSetsModels.questionsQuestionSetsModelWithIdAdd;

            _mapperMock.Setup(x => x.Map<QuestionsQuestionSetsEntity>(It.IsAny<QuestionsQuestionSets>()))
                .Returns(questionsQuestionSetsEntity);
            _repoMock.Setup(x => x.Add(It.IsAny<QuestionsQuestionSetsEntity>(), default)).ReturnsAsync(questionsQuestionSetsEntityWithId);
            _mapperMock.Setup(x => x.Map<QuestionsQuestionSets>(It.IsAny<QuestionsQuestionSetsEntity>()))
                .Returns(questionsQuestionSetsWithId);
            // Act
            var actual = await _service.Add(questionsQuestionSets, default);

            // Assert
            Assert.Equal(questionsQuestionSetsWithId, actual);
        }

        [Fact]
        public void GetQuestionsQuestionSetsByPredicate_ValidPredicate_ReturnsQuestionsQuestionSetsList()
        {
            var questionsQuestionSetsEntities = ValidQuestionsQuestionSetsEntities.questionsQuestionSetsEntitiesGetByPredicate;
            var questionsQuestionSetsModels = ValidQuestionsQuestionSetsModels.questionsQuestionSetsModelsGetByPredicate;

            _repoMock.Setup(x => x.Get(It.IsAny<Expression<Func<QuestionsQuestionSetsEntity, bool>>>(), default)).ReturnsAsync(questionsQuestionSetsEntities);
            _mapperMock.Setup(x => x.Map<IEnumerable<QuestionsQuestionSets>>(It.IsAny<IEnumerable<QuestionsQuestionSetsEntity>>()))
                .Returns(questionsQuestionSetsModels);
            var result = _service.Get(x => x.QuestionSetId == 1, default);
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task DeleteQuestionQuestionSets_ValidIds_ReturnsNull()
        {
            _repoMock.Setup(x => x.Delete(int.MaxValue, int.MaxValue, default));

            await _service.Delete(5, 10, default).ShouldNotThrowAsync();
        }
    }
}