using AIS.DAL.Entities;
using AIS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AIS.DAL.Tests.Repositories.Company
{
    public class CompanyRepositoryTests
    {
        private readonly DbContextOptions<DatabaseContext> _options;
        private CompanyRepository _repository;

        public CompanyRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "CompanyDataBase")
                .Options;
        }

        [Fact]
        public async Task GetCompanyById_ValidId_ReturnsCompanyEntity()
        {
            var model = new CompanyEntity
            {
                Name = "asd",
                Employees = new HashSet<EmployeeEntity>
                {
                    new()
                    {
                        Name = "asd",
                    }
                },
                Interviewees = new HashSet<IntervieweeEntity>
                {
                    new()
                    {
                        Name = "asd"
                    }
                }
            };

            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var entity = await context.Companies.AddAsync(model);
            await context.SaveChangesAsync();

            var company = await _repository.GetById(entity.Entity.Id, default);

            company.ShouldNotBeNull();
            company.ShouldBeEquivalentTo(entity.Entity);
        }

        [Fact]
        public async Task GetCompanies_ValidModels_ReturnsCompanyEntityList()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.Companies.Add(new CompanyEntity
            {
                Name = "asd"
            });

            context.Companies.Add(new CompanyEntity
            {
                Name = "dsa"
            });

            await context.SaveChangesAsync();

            var employee = await _repository.Get(default);

            employee.ShouldNotBeNull();
        }

        [Fact]
        public async Task AddCompany_ValidModel_ReturnsCompanyEntity()
        {
            var model = new CompanyEntity()
            {
                Name = "asd"
            };

            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var employee = await _repository.Add(model, default);

            employee.ShouldNotBeNull();
        }

        [Fact]
        public async Task UpdateCompany_ValidModel_ReturnsCompanyEntity()
        {
            var addedModel = new CompanyEntity
            {
                Name = "asd"
            };

            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var entity = await context.Companies.AddAsync(addedModel);
            await context.SaveChangesAsync();
            
            var company = await _repository.Update(entity.Entity, default);

            company.ShouldNotBeNull();
            company.ShouldBeEquivalentTo(entity.Entity);
        }

        [Fact]
        public async Task GetCompaniesByPredicate_ValidPredicate_ReturnsCompanyEntityList()
        {
            var model = new[] {
                    new CompanyEntity
                    {
                        Name = "asd"
                    }
                };

            await using DatabaseContext context = new(_options);
            _repository = new(context);

            context.Companies.Add(model[0]);
            await context.SaveChangesAsync();

            var employee = await _repository.Get(x => x.Id == model[0].Id, default);

            employee.ShouldNotBeNull();
        }

        [Fact]
        public async Task DeleteCompany_ValidModel_NotThrow()
        {
            var employeeModel = new CompanyEntity
            {
                Name = "asd",
            };

            await using DatabaseContext context = new(_options);
            _repository = new(context);

            context.Companies.Add(employeeModel);
            await context.SaveChangesAsync();

            await _repository.Delete(employeeModel, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task DeleteCompany_ValidId_NotThrow()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            context.Companies.Add(new CompanyEntity
            {
                Name = "asd"
            });
            await context.SaveChangesAsync();

            await _repository.Delete(1, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task GetCompanyById_InvalidId_ReturnsNull()
        {
            var model = new CompanyEntity
            {
                Name = "asd"
            };

            await using DatabaseContext context = new(_options);
            _repository = new(context);

            context.Companies.Add(model);
            await context.SaveChangesAsync();

            var employee = await _repository.GetById(-8, default);

            employee.ShouldBeNull();
        }

        [Fact]
        public async Task GetCompanies_NoModels_ReturnsEmptyCompanyEntityList()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            await context.Database.EnsureDeletedAsync();
            var employee = await _repository.Get(default);

            employee.ShouldBeEmpty();
        }

        [Fact]
        public async Task AddCompany_InvalidModel_ThrowArgumentNullException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            await _repository.Add(null, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task UpdateCompany_InvalidModel_ThrowDbUpdateConcurrencyException()
        {
            var expectedModel = new CompanyEntity
            {
                Name = "Name"
            };

            var addedModel = new CompanyEntity();

            await using DatabaseContext context = new(_options);
            _repository = new(context);

            await context.Companies.AddAsync(addedModel);
            await context.SaveChangesAsync();

            await _repository.Update(expectedModel, default).ShouldThrowAsync(typeof(DbUpdateConcurrencyException));
        }

        [Fact]
        public async Task GetCompaniesByPredicate_ValidPredicate_ReturnsEmptyCompanyEntityList()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            {
                var employee = await _repository.Get(x => x.Id == -1, default);

                employee.ShouldBeEmpty();
            }
        }

        [Fact]
        public async Task DeleteCompany_InvalidModel_ThrowNullArgumentException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var employeeModel = new CompanyEntity
            {
                Id = -1
            };

            await _repository.Delete(employeeModel, default).ShouldThrowAsync(typeof(DbUpdateConcurrencyException));
        }

        [Fact]
        public async Task DeleteCompany_InvalidId_ThrowDbUpdateConcurrencyException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            await _repository.Delete(-123, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }
    }
}
