using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AIS.DAL.Repositories;
using AIS.DAL.Tests.Entity;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AIS.DAL.Tests.Repositories.QuestionArea
{
    public class QuestionAreaRepostitoryTests
    {
        private readonly DbContextOptions<DatabaseContext> _options;
        private IQuestionAreaRepository _repository;

        public QuestionAreaRepostitoryTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "AreaDataBase")
                .Options;
        }

        [Fact]
        public async Task GetQuestionAreaById_ValidId_ReturnsQuestionAreaEntity()
        {
            var model = ValidQuestionAreasEntities.ValidGetQuestionAreaById;

            await using DatabaseContext context = new(_options);
            _repository = new QuestionAreaRepository(context);
            var entity = context.QuestionAreas.Add(model);

            await context.SaveChangesAsync();

            var result = await _repository.GetById(entity.Entity.Id, default);

            result.ShouldNotBeNull();
            result.Name.ShouldBeEquivalentTo(entity.Entity.Name);
        }

        [Fact]
        public async Task GetQuestionAreas_ValidModels_ReturnsQuestionAreaEntityList()
        {
            var models = ValidQuestionAreasEntities.ValidGetQuestionAreas;
            await using DatabaseContext context = new(_options);
            _repository = new QuestionAreaRepository(context);

            await context.AddRangeAsync(models);
            await context.SaveChangesAsync();

            var res = await _repository.Get(default);

            res.ShouldNotBeNull();
        }

        [Fact]
        public async Task AddQuestionArea_ValidModel_ReturnsQuestionAreaEntity()
        {
            await using DatabaseContext context = new(_options);
            _repository = new QuestionAreaRepository (context);
            var model = ValidQuestionAreasEntities.ValidAddQuestionArea;

            var res = await _repository.Add(model, default);

            res.ShouldNotBeNull();
        }

        [Fact]
        public async Task UpdateQuestionArea_ValidModel_ReturnsQuestionAreaEntity()
        {
            var addedModel = ValidQuestionAreasEntities.ValidUpdateQuestionAreaAdded;
            var updateModel = ValidQuestionAreasEntities.ValidUpdateQuestionAreaUpdated;
            await using DatabaseContext context = new(_options);
            _repository = new QuestionAreaRepository(context);
            var entity = await context.QuestionAreas.AddAsync(addedModel);

            await context.SaveChangesAsync();

            updateModel.Id = entity.Entity.Id;

            var res = await _repository.Update(entity.Entity, default);

            res.ShouldNotBeNull();
            res.ShouldBeEquivalentTo(entity.Entity);
        }

        [Fact]
        public async Task GetQuestionAreaByPredicate_ValidPredicate_ReturnsQuestionAreaEntityList()
        {
            var models = ValidQuestionAreasEntities.ValidGetQuestionAreaByPredicate;

            await using DatabaseContext context = new(_options);
            _repository = new QuestionAreaRepository(context);

            await context.QuestionAreas.AddRangeAsync(models);

            await context.SaveChangesAsync();

            var result = await _repository.Get(x => x.Name == "Question area GetQuestionAreaByPredicate", default);

            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task DeleteQuestionArea_ValidModel_NotThrow()
        {
            var model = ValidQuestionAreasEntities.ValidDeleteQuestionArea;

            await using DatabaseContext context = new(_options);
            _repository = new QuestionAreaRepository(context);
            var entity = context.QuestionAreas.Add(model);

            await context.SaveChangesAsync();

            model.Id = entity.Entity.Id;

            await _repository.Delete(model, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task DeleteQuestionArea_ValidId_NotThrow()
        {
            await using DatabaseContext context = new(_options);
            _repository = new QuestionAreaRepository(context);

            await _repository.Delete(1, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task GetQuestionAreaById_InvalidId_ReturnsNull()
        {
            await using DatabaseContext context = new(_options);
            _repository = new QuestionAreaRepository(context);

            var result = await _repository.GetById(-8, default);

            result.ShouldBeNull();
        }

        [Fact]
        public async Task GetQuestionAreas_NoModels_ReturnsEmptyQuestionAreaList()
        {
            await using DatabaseContext context = new(_options);
            _repository = new QuestionAreaRepository(context);
            await context.Database.EnsureDeletedAsync();

            var result = await _repository.Get(default);

            result.ShouldBeEmpty();
        }

        [Fact]
        public async Task AddQuestionArea_InvalidModel_ThrowArgumentNullException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new QuestionAreaRepository(context);
            await _repository.Add(null, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task UpdateQuestionArea_InvalidModel_ThrowDbUpdateConcurrencyException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new QuestionAreaRepository(context);

            await _repository.Update(null, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task GetQuestionAreaByPredicate_ValidPredicate_ReturnsEmptyQuestionAreaEntityList()
        {
            await using DatabaseContext context = new(_options);
            _repository = new QuestionAreaRepository(context);
            var result = await _repository.Get(x => x.Id == -1, default);

            result.ShouldBeEmpty();
        }

        [Fact]
        public async Task DeleteQuestionArea_InvalidModel_ThrowNullArgumentException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new QuestionAreaRepository(context);
            await _repository.Delete(null, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task DeleteQuestionArea_InvalidId_ThrowDbUpdateConcurrencyException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new QuestionAreaRepository(context);
            await _repository.Delete(-1, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }
    }
}
