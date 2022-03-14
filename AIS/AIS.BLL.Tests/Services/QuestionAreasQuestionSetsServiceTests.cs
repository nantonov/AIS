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
    public class QuestionAreasQuestionSetsServiceTests
    {
        private readonly IQuestionAreasQuestionSetsService _service;
        private readonly Mock<IQuestionAreasQuestionSetsRepository> _repoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        public QuestionAreasQuestionSetsServiceTests()
        {
            _service = new QuestionAreasQuestionSetsService(_repoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetQuestionAreasQuestionSets_HasData_ReturnQuestionAreasQuestionSetsList()
        {
            var questionAreasQuestionSetsEntities = ValidQuestionAreasQuestionSetsEntities.questionAreasQuestionSetsEntitiesGet;
            var questionAreasQuestionSetsModels = ValidQuestionAreasQuestionSetsModels.questionAreasQuestionSetsModelsGet;
            _mapperMock.Setup(x => x.Map<IEnumerable<QuestionAreasQuestionSets>>(It.IsAny<IEnumerable<QuestionAreasQuestionSetsEntity>>()))
                .Returns(questionAreasQuestionSetsModels);
            _repoMock.Setup(x => x.Get(default)).ReturnsAsync(questionAreasQuestionSetsEntities);
            var result = await _service.Get(default);
            Assert.NotNull(result);
            Assert.Equal(questionAreasQuestionSetsModels.Count, result.Count());
            result.ShouldBeEquivalentTo(questionAreasQuestionSetsModels);
        }

        [Fact]
        public async Task GetQuestionAreasQuestionSets_HasNotData_ReturnQuestionAreasQuestionSetsList()
        {
            List<QuestionAreasQuestionSetsEntity> questionAreasQuestionSetsEntities = new();
            List<QuestionAreasQuestionSets> questionAreasQuestionSetsModels = new();
            _repoMock.Setup(x => x.Get(default)).ReturnsAsync(questionAreasQuestionSetsEntities);
            _mapperMock.Setup(x => x.Map<IEnumerable<QuestionAreasQuestionSets>>(It.IsAny<IEnumerable<QuestionAreasQuestionSetsEntity>>())).Returns(questionAreasQuestionSetsModels);
            var result = await _service.Get(default);
            Assert.Equal(new List<QuestionAreasQuestionSets>(), result);
        }

        [Fact]
        public async Task GetQuestionAreasQuestionSetsById_ValidId_ReturnsQuestionAreasQuestionSetsById()
        {
            var questionAreasQuestionSetsEntity = ValidQuestionAreasQuestionSetsEntities.questionAreasQuestionSetsEntityGetById;
            var questionAreasQuestionSets = ValidQuestionAreasQuestionSetsModels.questionAreasQuestionSetsModelGetById;

            _repoMock.Setup(x => x.GetById(6, default)).ReturnsAsync(questionAreasQuestionSetsEntity);
            _mapperMock.Setup(x => x.Map<QuestionAreasQuestionSets>(It.IsAny<QuestionAreasQuestionSetsEntity>())).Returns(questionAreasQuestionSets);
            // Act
            var actual = await _service.GetById(questionAreasQuestionSets.Id, default);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(questionAreasQuestionSets.Id, actual.Id);
        }

        [Fact]
        public async Task GetQuestionAreasQuestionSetsById_InvalidId_ReturnsNullQuestionAreasQuestionSetsById()
        {
            QuestionAreasQuestionSetsEntity questionAreasQuestionSetsEntity = null;
            QuestionAreasQuestionSets questionAreasQuestionSets = null;

            _repoMock.Setup(x => x.GetById(int.MaxValue, default)).ReturnsAsync(questionAreasQuestionSetsEntity);
            _mapperMock.Setup(x => x.Map<QuestionAreasQuestionSets>(It.IsAny<QuestionAreasQuestionSetsEntity>()))
                .Returns(questionAreasQuestionSets);

            // Act
            var actual = await _service.GetById(int.MaxValue, default);

            // Assert
            Assert.Null(actual);
        }

        [Fact]
        public async Task DeleteQuestionAreasQuestionSets_ValidId_ReturnsNull()
        {
            _repoMock.Setup(x => x.Delete(int.MaxValue, default));

            await _service.Delete(20, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task DeleteQuestionAreasQuestionSets_ValidQuestionAreasQuestionSets_ReturnsNull()
        {
            var questionAreasQuestionSetsEntity = ValidQuestionAreasQuestionSetsEntities.questionAreasQuestionSetsEntityDelete;
            var questionAreasQuestionSets = ValidQuestionAreasQuestionSetsModels.questionAreasQuestionSetsModelDelete;

            _mapperMock.Setup(x => x.Map<QuestionAreasQuestionSetsEntity>(It.IsAny<QuestionAreasQuestionSets>()))
                .Returns(questionAreasQuestionSetsEntity);
            _repoMock.Setup(x => x.Delete(questionAreasQuestionSetsEntity, default));

            await _service.Delete(questionAreasQuestionSets, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task PutQuestionAreasQuestionSets_ValidQuestionAreasQuestionSets_ReturnsQuestionAreasQuestionSets()
        {
            var questionAreasQuestionSetsEntity = ValidQuestionAreasQuestionSetsEntities.questionAreasQuestionSetsEntityPut;
            var questionAreasQuestionSets = ValidQuestionAreasQuestionSetsModels.questionAreasQuestionSetsModelPut;

            _mapperMock.Setup(x => x.Map<QuestionAreasQuestionSetsEntity>(It.IsAny<QuestionAreasQuestionSets>()))
                .Returns(questionAreasQuestionSetsEntity);
            _repoMock.Setup(x => x.Update(questionAreasQuestionSetsEntity, default)).ReturnsAsync(() => questionAreasQuestionSetsEntity);
            _mapperMock.Setup(x => x.Map<QuestionAreasQuestionSets>(It.IsAny<QuestionAreasQuestionSetsEntity>()))
                .Returns(questionAreasQuestionSets);
            var expected = await _service.Put(questionAreasQuestionSets, default);
            Assert.NotNull(expected);
            Assert.Equal(questionAreasQuestionSets, expected);
        }

        [Fact]
        public async Task PutQuestionAreasQuestionSets_InvalidQuestionAreasQuestionSets_ReturnsNull()
        {
            var questionAreasQuestionSetsEntity = (QuestionAreasQuestionSetsEntity)null;

            _mapperMock.Setup(x => x.Map<QuestionAreasQuestionSetsEntity>(It.IsAny<QuestionAreasQuestionSets>())).Returns((QuestionAreasQuestionSetsEntity)null);
            _repoMock.Setup(x => x.Update(questionAreasQuestionSetsEntity, default)).ReturnsAsync((QuestionAreasQuestionSetsEntity)null);
            _mapperMock.Setup(x => x.Map<QuestionAreasQuestionSets>(It.IsAny<QuestionAreasQuestionSetsEntity>())).Returns((QuestionAreasQuestionSets)null);
            var result = await _service.Put(null, default);
            Assert.Null(result);
        }

        [Fact]
        public async Task AddQuestionAreasQuestionSets_ValidQuestionAreasQuestionSets_ReturnsQuestionAreasQuestionSets()
        {
            var questionAreasQuestionSetsEntity = ValidQuestionAreasQuestionSetsEntities.questionAreasQuestionSetsEntityAdd;
            var questionAreasQuestionSets = ValidQuestionAreasQuestionSetsModels.questionAreasQuestionSetsModelAdd;
            var questionAreasQuestionSetsEntityWithId = ValidQuestionAreasQuestionSetsEntities.questionAreasQuestionSetsEntityDelete;
            var questionAreasQuestionSetsWithId = ValidQuestionAreasQuestionSetsModels.questionAreasQuestionSetsModelAddWithId;

            _mapperMock.Setup(x => x.Map<QuestionAreasQuestionSetsEntity>(It.IsAny<QuestionAreasQuestionSets>()))
                .Returns(questionAreasQuestionSetsEntity);
            _repoMock.Setup(x => x.Add(It.IsAny<QuestionAreasQuestionSetsEntity>(), default)).ReturnsAsync(questionAreasQuestionSetsEntityWithId);
            _mapperMock.Setup(x => x.Map<QuestionAreasQuestionSets>(It.IsAny<QuestionAreasQuestionSetsEntity>()))
                .Returns(questionAreasQuestionSetsWithId);
            // Act
            var actual = await _service.Add(questionAreasQuestionSets, default);

            // Assert
            Assert.Equal(questionAreasQuestionSetsWithId, actual);
        }

        [Fact]
        public void GetQuestionAreasQuestionSetsByPredicate_ValidPredicate_ReturnsQuestionAreasQuestionSetsList()
        {
            var questionAreasQuestionSetsEntities = ValidQuestionAreasQuestionSetsEntities.questionAreasQuestionSetsEntitiesGetByPredicate;
            var questionAreasQuestionSetsModels = ValidQuestionAreasQuestionSetsModels.questionAreasQuestionSetsModelsGetByPredicate;

            _repoMock.Setup(x => x.Get(It.IsAny<Expression<Func<QuestionAreasQuestionSetsEntity, bool>>>(), default)).ReturnsAsync(questionAreasQuestionSetsEntities);
            _mapperMock.Setup(x => x.Map<IEnumerable<QuestionAreasQuestionSets>>(It.IsAny<IEnumerable<QuestionAreasQuestionSetsEntity>>()))
                .Returns(questionAreasQuestionSetsModels);
            var result = _service.Get(x => x.QuestionSetId == 1, default);
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task DeleteQuestionAreasQuestionSets_ValidIds_ReturnsNull()
        {
            _repoMock.Setup(x => x.Delete(int.MaxValue,int.MaxValue, default));

            await _service.Delete(5,10, default).ShouldNotThrowAsync();
        }
    }
}