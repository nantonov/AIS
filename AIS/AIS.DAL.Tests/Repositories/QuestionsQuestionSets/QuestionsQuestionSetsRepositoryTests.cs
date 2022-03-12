using AIS.DAL.Entities;
using AIS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AIS.DAL.Tests.Repositories.QuestionsQuestionSets
{
    public class QuestionsQuestionSetsRepositoryTests
    {
        private readonly DbContextOptions<DatabaseContext> _options;
        private QuestionsQuestionSetsRepository _repository;
        public QuestionsQuestionSetsRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "QuestionsQuestionSetsDatabaseTests")
                .Options;
        }

        [Fact]
        public async Task GetQuestionsQuestionSetsById_ValidId_ReturnsQuestionsQuestionSetsEntity()
        {
            var set = new QuestionSetEntity
            {
                Name = "asd"
            };
            var question = new QuestionEntity
            {
                Text = "das"
            };

            var model = new QuestionsQuestionSetsEntity()
            {
                QuestionId = 1,
                QuestionSetId = 1
            };

            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.QuestionSets.Add(set);
            context.Questions.Add(question);
            var entity = context.QuestionsQuestionSets.Add(model);

            await context.SaveChangesAsync();

            var result = await _repository.GetById(entity.Entity.Id, default);

            result.ShouldNotBeNull();
            result.Id.ShouldBeEquivalentTo(entity.Entity.Id);
            result.QuestionSetId.ShouldBeEquivalentTo(entity.Entity.QuestionSetId);
            result.QuestionId.ShouldBeEquivalentTo(entity.Entity.QuestionId);
        }

        [Fact]
        public async Task GetQuestionsQuestionSets_ValidModels_ReturnsQuestionsQuestionSetsEntityList()
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
            var questions = new List<QuestionEntity>
            {
                new()
                {
                    Text = "my area name 1"
                },
                new()
                {
                    Text = "my area name 2"
                }
            };

            var questionsQuestionSets = new List<QuestionsQuestionSetsEntity>()
            {
                new()
                {
                    QuestionSetId = 1,
                    QuestionId = 1
                },
                new()
                {
                    QuestionSetId = 2,
                    QuestionId = 1
                },
                new()
                {
                    QuestionSetId = 1,
                    QuestionId = 2
                }
            };
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.QuestionSets.AddRange(sets);
            context.Questions.AddRange(questions);
            context.QuestionsQuestionSets.AddRange(questionsQuestionSets);
            var entity = context.QuestionsQuestionSets;
            await context.SaveChangesAsync();

            var result = await _repository.Get(default);

            result.ShouldNotBeNull();
            result.Count().ShouldBe(entity.Count());
        }

        [Fact]
        public async Task AddQuestionsQuestionSets_ValidModel_ReturnsQuestionsQuestionSetsEntity()
        {
            var set = new QuestionSetEntity
            {
                Name = "asd"
            };
            var question = new QuestionEntity
            {
                Text = "das"
            };

            var model = new QuestionsQuestionSetsEntity()
            {
                QuestionId = 1,
                QuestionSetId = 1
            };
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.Questions.Add(question);
            context.QuestionSets.Add(set);

            var result = await _repository.Add(model, default);

            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task UpdateQuestionsQuestionSets_ValidModel_ReturnsQuestionsQuestionSetsEntity()
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
            var question = new QuestionEntity
            {
                Text = "das"
            };

            var model = new QuestionsQuestionSetsEntity()
            {
                QuestionId = 1,
                QuestionSetId = 1
            };

            var modelUpdate = new QuestionsQuestionSetsEntity()
            {
                QuestionId = 1,
                QuestionSetId = 2
            };

            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.Questions.Add(question);
            context.QuestionSets.AddRange(sets);
            var entity = context.QuestionsQuestionSets.Add(model);
            await context.SaveChangesAsync();

            context.Entry(entity.Entity).State = EntityState.Detached;

            modelUpdate.Id = entity.Entity.Id;

            var result = await _repository.Update(modelUpdate, default);

            result.ShouldNotBeNull();
            result.QuestionSetId.ShouldBe(modelUpdate.QuestionSetId);
        }

        [Fact]
        public async Task GetQuestionsQuestionSetsByPredicate_ValidModels_ReturnsQuestionsQuestionSetsEntityList()
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
            var questions = new List<QuestionEntity>
            {
                new()
                {
                    Text = "my area name 1"
                },
                new()
                {
                    Text = "my area name 2"
                }
            };

            var questionsQuestionSetsEntity = new List<QuestionsQuestionSetsEntity>()
            {
                new()
                {
                    QuestionSetId = 1,
                    QuestionId = 1
                },
                new()
                {
                    QuestionSetId = 2,
                    QuestionId = 1
                },
                new()
                {
                    QuestionSetId = 1,
                    QuestionId = 2
                }
            };
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.QuestionSets.AddRange(sets);
            context.Questions.AddRange(questions);
            context.QuestionsQuestionSets.AddRange(questionsQuestionSetsEntity);
            var entity = context.QuestionsQuestionSets;
            await context.SaveChangesAsync();

            var result = await _repository.Get(x => x.QuestionSetId == 1, default);

            result.ShouldNotBeNull();
            result.Count().ShouldBe(entity.Where(x => x.QuestionSetId == 1).Count());
        }

        [Fact]
        public async Task DeleteQuestionsQuestionSets_ValidModel_NotThrow()
        {
            var set = new QuestionSetEntity
            {
                Name = "asd"
            };
            var question = new QuestionEntity
            {
                Text = "das"
            };

            var model = new QuestionsQuestionSetsEntity()
            {
                QuestionId = 1,
                QuestionSetId = 1
            };
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.QuestionSets.Add(set);
            context.Questions.Add(question);
            context.QuestionsQuestionSets.Add(model);

            await context.SaveChangesAsync();

            await _repository.Delete(model, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task DeleteQuestionsQuestionSets_ValidId_NotThrow()
        {
            var set = new QuestionSetEntity
            {
                Name = "asd"
            };
            var question = new QuestionEntity
            {
                Text = "das"
            };

            var model = new QuestionsQuestionSetsEntity()
            {
                QuestionId = 1,
                QuestionSetId = 1
            };
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.QuestionSets.Add(set);
            context.Questions.Add(question);
            context.QuestionsQuestionSets.Add(model);

            await context.SaveChangesAsync();

            await _repository.Delete(1, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task GetQuestionsQuestionSetsById_InvalidId_ReturnsNull()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var result = await _repository.GetById(-8, default);

            result.ShouldBeNull();
        }

        [Fact]
        public async Task GetQuestionsQuestionSets_NoEntities_ReturnsEmptyQuestionsQuestionSetsList()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            await context.Database.EnsureDeletedAsync();

            var result = await _repository.Get(default);

            result.ShouldBeEmpty();
        }

        [Fact]
        public async Task AddQuestionsQuestionSets_InvalidModel_ThrowArgumentNullException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            await _repository.Add(null, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task UpdateQuestionsQuestionSets_InvalidModel__ThrowDbUpdateConcurrencyException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            await _repository.Update(null, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task GetQuestionsQuestionSetsByPredicate_ValidModels_ReturnsEmptyQuestionsQuestionSetsEntityList()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var result = await _repository.Get(x => x.Id == -1, default);

            result.ShouldBeEmpty();
        }

        [Fact]
        public async Task DeleteQuestionsQuestionSets_InvalidModel_ThrowNullArgumentException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            await _repository.Delete(null, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task DeleteQuestionsQuestionSets_InvalidId_ThrowDbUpdateConcurrencyException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            await _repository.Delete(-1, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }
        [Fact]
        public async Task DeleteQuestionsQuestionSets_ValidIds_NotThrow()
        {
            var set = new QuestionSetEntity
            {
                Name = "OOP"
            };
            var question = new QuestionEntity
            {
                Text = "OOP"
            };

            var model = new QuestionsQuestionSetsEntity()
            {
                QuestionId = 1,
                QuestionSetId = 1
            };
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.QuestionSets.Add(set);
            context.Questions.Add(question);
            context.QuestionsQuestionSets.Add(model);

            await context.SaveChangesAsync();

            await _repository.Delete(1,1, default).ShouldNotThrowAsync();
        }
    }
}
