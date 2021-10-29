using AIS.DAL.Entities;
using AIS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AIS.DAL.Tests.Repositories.Interviewee
{
    public class IntervieweeRepositoryTests
    {
        private readonly DbContextOptions<DatabaseContext> _options;
        private IntervieweeRepository _repository;

        public IntervieweeRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "IntervieweeDataBase")
                .Options;
        }

        [Fact]
        public async Task GetIntervieweeById_ValidId_ReturnsIntervieweeEntity()
        {
            var model = new IntervieweeEntity
            {
                CompanyId = 1,
                Name = "asd"
            };
            var company = new CompanyEntity
            {
                Name = "das"
            };

            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var entity = context.Interviewees.Add(model);
            context.Companies.Add(company);

            await context.SaveChangesAsync();

            var interviewee = await _repository.GetById(entity.Entity.Id, default);

            interviewee.ShouldNotBeNull();
            interviewee.ShouldBeEquivalentTo(entity.Entity);
        }

        [Fact]
        public async Task GetInterviewees_ValidModels_ReturnsIntervieweeEntityList()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.Interviewees.Add(new IntervieweeEntity
            {
                CompanyId = 1,
                Name = "asd"
            });

            context.Interviewees.Add(new IntervieweeEntity
            {
                CompanyId = 1,
                Name = "dsa"
            });

            context.Companies.Add(new CompanyEntity
            {
                Name = "asd"
            });

            await context.SaveChangesAsync();

            var interviewee = await _repository.Get(default);

            interviewee.ShouldNotBeNull();
        }

        [Fact]
        public async Task AddInterviewee_ValidModel_ReturnsIntervieweeEntity()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var model = new IntervieweeEntity()
            {
                CompanyId = 2,
                Name = "asd"
            };

            var interviewee = await _repository.Add(model, default);

            interviewee.ShouldNotBeNull();
        }

        [Fact]
        public async Task UpdateInterviewee_ValidModel_ReturnsIntervieweeEntity()
        {
            var addedModel = new IntervieweeEntity
            {
                CompanyId = 6,
                Name = "asd"
            };

            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var entity = await context.Interviewees.AddAsync(addedModel);
            await context.SaveChangesAsync();

            await context.Companies.AddAsync(new CompanyEntity
            {
                Name = "asd"
            });

            await context.SaveChangesAsync();

            var interviewee = await _repository.Update(entity.Entity, default);

            interviewee.ShouldNotBeNull();
            interviewee.ShouldBeEquivalentTo(entity.Entity);
        }

        [Fact]
        public async Task GetIntervieweesByPredicate_ValidPredicate_ReturnsIntervieweeEntityList()
        {
            var model = new[] {
                    new IntervieweeEntity
                    {
                        CompanyId = 5,
                        Name = "asd"
                    }
                };

            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.Companies.Add(new CompanyEntity
            {
                Name = "asd"
            });

            var entity = context.Interviewees.Add(model[0]);

            await context.SaveChangesAsync();

            var interviewee = await _repository.Get(x => x.Id == entity.Entity.Id, default);

            interviewee.ShouldNotBeNull();
        }

        [Fact]
        public async Task DeleteInterviewee_ValidModel_NotThrow()
        {
            var intervieweeModel = new IntervieweeEntity
            {
                CompanyId = 2,
                Name = "asd",
            };

            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.Interviewees.Add(intervieweeModel);

            await context.SaveChangesAsync();

            await _repository.Delete(intervieweeModel, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task DeleteInterviewee_ValidId_NotThrow()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            await _repository.Delete(1, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task GetIntervieweeById_InvalidId_ReturnsNull()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var interviewee = await _repository.GetById(-8, default);

            interviewee.ShouldBeNull();
        }

        [Fact]
        public async Task GetInterviewees_NoModels_ReturnsEmptyIntervieweeEntityList()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            await context.Database.EnsureDeletedAsync();

            var interviewee = await _repository.Get(default);

            interviewee.ShouldBeEmpty();
        }

        [Fact]
        public async Task AddInterviewee_InvalidModel_ThrowArgumentNullException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            await _repository.Add(null, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task UpdateInterviewee_InvalidModel_ThrowDbUpdateConcurrencyException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            await _repository.Update(null, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task GetIntervieweesByPredicate_ValidPredicate_ReturnsEmptyIntervieweeEntityList()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var interviewee = await _repository.Get(x => x.Id == -1, default);

            interviewee.ShouldBeEmpty();
        }

        [Fact]
        public async Task DeleteInterviewee_InvalidModel_ThrowNullArgumentException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            await _repository.Delete(null, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task DeleteInterviewee_InvalidId_ThrowDbUpdateConcurrencyException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            await _repository.Delete(-1, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }
    }
}