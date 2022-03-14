using AIS.DAL.Entities;
using AIS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AIS.DAL.Tests.Repositories.QuestionAreasQuestionSets
{
    public class QuestionAreasQuestionSetsRepositoryTests
    {
        private readonly DbContextOptions<DatabaseContext> _options;
        private QuestionAreasQuestionSetsRepository _repository;
        public QuestionAreasQuestionSetsRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "QuestionAreasQuestionSetsDatabaseTests")
                .Options;
        }

        [Fact]
        public async Task GetQuestionAreasQuestionSetsById_ValidId_ReturnsQuestionAreasQuestionSetsEntity()
        {
            var set = new QuestionSetEntity
            {
                Name = "asd"
            };
            var area = new QuestionAreaEntity
            {
                Name = "das"
            };

            var model = new QuestionAreasQuestionSetsEntity()
            {
                QuestionAreaId = 1,
                QuestionSetId = 1
            };

            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.QuestionSets.Add(set);
            context.QuestionAreas.Add(area);
            var entity = context.QuestionAreasQuestionSets.Add(model);

            await context.SaveChangesAsync();

            var result = await _repository.GetById(entity.Entity.Id, default);

            result.ShouldNotBeNull();
            result.Id.ShouldBeEquivalentTo(entity.Entity.Id);
            result.QuestionSetId.ShouldBeEquivalentTo(entity.Entity.QuestionSetId);
            result.QuestionAreaId.ShouldBeEquivalentTo(entity.Entity.QuestionAreaId);
        }

        [Fact]
        public async Task GetQuestionAreasQuestionSets_ValidModels_ReturnsQuestionAreasQuestionSetsEntityList()
        {
            var sets = new List<QuestionSetEntity>
            {
                new()
                {
                    Name = "my set name 1"
                },
                new()
                {
                    Name = "my set name 2"
                }
            };
            var areas = new List<QuestionAreaEntity>
            {
                new()
                {
                    Name = "my area name 1"
                },
                new()
                {
                    Name = "my area name 2"
                }
            };

            var questionAreasQuestionSets = new List<QuestionAreasQuestionSetsEntity>()
            {
                new()
                {
                    QuestionSetId = 1,
                    QuestionAreaId = 1
                },
                new()
                {
                    QuestionSetId = 2,
                    QuestionAreaId = 1
                },
                new()
                {
                    QuestionSetId = 1,
                    QuestionAreaId = 2
                }
            };
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.QuestionSets.AddRange(sets);
            context.QuestionAreas.AddRange(areas);
            context.QuestionAreasQuestionSets.AddRange(questionAreasQuestionSets);
            var entity = context.QuestionAreasQuestionSets;
            await context.SaveChangesAsync();

            var result = await _repository.Get(default);

            result.ShouldNotBeNull();
            result.Count().ShouldBe(entity.Count());
        }

        [Fact]
        public async Task AddQuestionAreasQuestionSets_ValidModel_ReturnsQuestionAreasQuestionSetsEntity()
        {
            var set = new QuestionSetEntity
            {
                Name = "asd"
            };
            var area = new QuestionAreaEntity
            {
                Name = "das"
            };

            var model = new QuestionAreasQuestionSetsEntity()
            {
                QuestionAreaId = 1,
                QuestionSetId = 1
            };
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.QuestionAreas.Add(area);
            context.QuestionSets.Add(set);

            var result = await _repository.Add(model, default);

            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task UpdateQuestionAreasQuestionSets_ValidModel_ReturnsQuestionAreasQuestionSetsEntity()
        {
            var sets = new List<QuestionSetEntity>
            {
                new()
                {
                    Name = "asd"
                },
                new()
                {
                    Name = "derft"
                }

            };
            var area = new QuestionAreaEntity
            {
                Name = "das"
            };

            var model = new QuestionAreasQuestionSetsEntity()
            {
                QuestionAreaId = 1,
                QuestionSetId = 1
            };

            var modelUpdate = new QuestionAreasQuestionSetsEntity()
            {
                Id = 1,
                QuestionAreaId = 1,
                QuestionSetId = 2
            };

            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.QuestionAreas.Add(area);
            context.QuestionSets.AddRange(sets);
            var entity = context.QuestionAreasQuestionSets.Add(model);
            await context.SaveChangesAsync();

            context.Entry(entity.Entity).State = EntityState.Detached;

            var result = await _repository.Update(modelUpdate, default);

            result.ShouldNotBeNull();
            result.QuestionSetId.ShouldBe(modelUpdate.QuestionSetId);
        }

        [Fact]
        public async Task GetQuestionAreasQuestionSetsByPredicate_ValidModels_ReturnsQuestionAreasQuestionSetsEntityList()
        {
            var sets = new List<QuestionSetEntity>
            {
                new()
                {
                    Name = "my set name 1"
                },
                new()
                {
                    Name = "my set name 2"
                }
            };
            var areas = new List<QuestionAreaEntity>
            {
                new()
                {
                    Name = "my area name 1"
                },
                new()
                {
                    Name = "my area name 2"
                }
            };

            var questionAreasQuestionSets = new List<QuestionAreasQuestionSetsEntity>()
            {
                new()
                {
                    QuestionSetId = 1,
                    QuestionAreaId = 1
                },
                new()
                {
                    QuestionSetId = 2,
                    QuestionAreaId = 1
                },
                new()
                {
                    QuestionSetId = 1,
                    QuestionAreaId = 2
                }
            };
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.QuestionSets.AddRange(sets);
            context.QuestionAreas.AddRange(areas);
            context.QuestionAreasQuestionSets.AddRange(questionAreasQuestionSets);
            var entity = context.QuestionAreasQuestionSets;
            await context.SaveChangesAsync();

            var result = await _repository.Get(x => x.QuestionSetId == 1, default);

            result.ShouldNotBeNull();
            result.Count().ShouldBe(entity.Where(x => x.QuestionSetId == 1).Count());
        }

        [Fact]
        public async Task DeleteQuestionAreasQuestionSets_ValidModel_NotThrow()
        {
            var set = new QuestionSetEntity
            {
                Name = "asd"
            };
            var area = new QuestionAreaEntity
            {
                Name = "das"
            };

            var model = new QuestionAreasQuestionSetsEntity()
            {
                QuestionAreaId = 1,
                QuestionSetId = 1
            };
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.QuestionSets.Add(set);
            context.QuestionAreas.Add(area);
            context.QuestionAreasQuestionSets.Add(model);

            await context.SaveChangesAsync();

            await _repository.Delete(model, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task DeleteQuestionAreasQuestionSets_ValidId_NotThrow()
        {
            var set = new QuestionSetEntity
            {
                Name = "asd"
            };
            var area = new QuestionAreaEntity
            {
                Name = "das"
            };

            var model = new QuestionAreasQuestionSetsEntity()
            {
                QuestionAreaId = 1,
                QuestionSetId = 1
            };
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.QuestionSets.Add(set);
            context.QuestionAreas.Add(area);
            context.QuestionAreasQuestionSets.Add(model);

            await context.SaveChangesAsync();

            await _repository.Delete(1, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task GetQuestionAreasQuestionSetsById_InvalidId_ReturnsNull()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var result = await _repository.GetById(-8, default);

            result.ShouldBeNull();
        }

        [Fact]
        public async Task GetQuestionAreasQuestionSets_NoEntities_ReturnsEmptyQuestionAreasQuestionSetsList()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            await context.Database.EnsureDeletedAsync();

            var result = await _repository.Get(default);

            result.ShouldBeEmpty();
        }

        [Fact]
        public async Task AddQuestionAreasQuestionSets_InvalidModel_ThrowArgumentNullException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            await _repository.Add(null, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task UpdateQuestionAreasQuestionSets_InvalidModel__ThrowDbUpdateConcurrencyException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            await _repository.Update(null, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task GetQuestionAreasQuestionSetsByPredicate_ValidModels_ReturnsEmptyQuestionAreasQuestionSetsEntityList()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var result = await _repository.Get(x => x.Id == -1, default);

            result.ShouldBeEmpty();
        }

        [Fact]
        public async Task DeleteQuestionAreasQuestionSets_InvalidModel_ThrowNullArgumentException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            await _repository.Delete(null, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task DeleteQuestionAreasQuestionSets_InvalidId_ThrowDbUpdateConcurrencyException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            await _repository.Delete(-1, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task DeleteQuestionAreasQuestionSets_ValidIds_NotThrow()
        {
            var set = new QuestionSetEntity
            {
                Name = "asd"
            };
            var area = new QuestionAreaEntity
            {
                Name = "das"
            };

            var model = new QuestionAreasQuestionSetsEntity()
            {
                QuestionAreaId = 1,
                QuestionSetId = 1
            };
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.QuestionSets.Add(set);
            context.QuestionAreas.Add(area);
            context.QuestionAreasQuestionSets.Add(model);

            await context.SaveChangesAsync();

            await _repository.Delete(1,1, default).ShouldNotThrowAsync();
        }
    }
}