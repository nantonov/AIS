using AIS.DAL.Entities;
using AIS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AIS.DAL.Tests.Repositories.Employee
{
    public class EmployeeRepositoryTests
    {
        private readonly DbContextOptions<DatabaseContext> _options;
        private EmployeeRepository _repository;

        public EmployeeRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "EmployeeDataBase")
                .Options;
        }

        [Fact]
        public async Task GetEmployeeById_ValidId_ReturnsEmployeeEntity()
        {
            var model = new EmployeeEntity
            {
                CompanyId = 1,
                Name = "asd"
            };
            var company = new CompanyEntity
            {
                Name = "dsa"
            };

            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var entity = context.Employees.Add(model);
            context.Companies.Add(company);

            await context.SaveChangesAsync();

            var employee = await _repository.GetById(entity.Entity.Id, default);

            employee.ShouldNotBeNull();
            employee.ShouldBeEquivalentTo(entity.Entity);
        }

        [Fact]
        public async Task GetEmployees_ValidModels_ReturnsEmployeeEntity()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            context.Employees.Add(new EmployeeEntity
            {
                CompanyId = 1,
                Name = "asd"
            });

            context.Employees.Add(new EmployeeEntity
            {
                CompanyId = 1,
                Name = "dsa"
            });

            context.Companies.Add(new CompanyEntity
            {
                Name = "asd"
            });

            await context.SaveChangesAsync();

            var ct = new CancellationToken();

            var employee = _repository.Get(ct);

            employee.Result.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task AddEmployee_ValidModel_ReturnsEmployeeEntity()
        {
            var model = new EmployeeEntity()
            {
                CompanyId = 2,
                Name = "asd"
            };

            var ct = new CancellationToken();

            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var employee = await _repository.Add(model, ct);

            employee.ShouldNotBeNull();
        }

        [Fact]
        public async Task UpdateEmployee_ValidModel_ReturnsEmployeeEntity()
        {
            var addedModel = new EmployeeEntity
            {
                CompanyId = 6,
                Name = "dsa"
            };

            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var entity = await context.Employees.AddAsync(addedModel);
            await context.SaveChangesAsync();

            await context.Companies.AddAsync(new CompanyEntity
            {
                Name = "asd"
            });

            await context.SaveChangesAsync();

            var employee = await _repository.Update(entity.Entity, default);

            employee.ShouldNotBeNull();
            employee.ShouldBeEquivalentTo(entity.Entity);
        }

        [Fact]
        public async Task GetEmployeesByPredicate_ValidPredicate_ReturnsEmployeeEntityList()
        {
            var model = new[] {
                    new EmployeeEntity
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

            var entity = context.Employees.Add(model[0]);

            await context.SaveChangesAsync();

            var employee = await _repository.Get(x => x.Id == entity.Entity.Id, default);

            employee.ShouldNotBeNull();
        }

        [Fact]
        public async Task DeleteEmployee_ValidModel_NotThrow()
        {
            var employeeModel = new EmployeeEntity
            {
                CompanyId = 2,
                Name = "asd",
            };

            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var entity = context.Employees.Add(employeeModel);

            await context.SaveChangesAsync();

            await _repository.Delete(entity.Entity, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task DeleteEmployee_ValidId_NotThrow()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var entity = context.Employees.Add(new EmployeeEntity
            {
                CompanyId = 2,
                Name = "asd"
            });

            await context.SaveChangesAsync();

            await _repository.Delete(entity.Entity.Id, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task GetEmployeeById_InvalidId_ReturnsNull()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var employee = await _repository.GetById(-8, default);

            employee.ShouldBeNull();
        }

        [Fact]
        public async Task GetEmployees_NoModels_ReturnsEmptyEmployeeEntityList()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            await context.Database.EnsureDeletedAsync();

            var ct = new CancellationToken();

            var employee = await _repository.Get(ct);

            employee.ShouldBeEmpty();
        }

        [Fact]
        public async Task AddEmployee_InvalidModel_ThrowArgumentNullException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var ct = new CancellationToken();
            var result = _repository.Add(null, ct);

            await result.ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task UpdateEmployee_InvalidModel_ThrowDbUpdateConcurrencyException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            await _repository.Update(null, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task GetEmployeesByPredicate_ValidPredicate_ReturnsEmptyEmployeeEntityList()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            var employee = await _repository.Get(x => x.Id == -1, default);

            employee.ShouldBeEmpty();
        }

        [Fact]
        public async Task DeleteEmployee_InvalidModel_ThrowNullArgumentException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            await _repository.Delete(null, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task DeleteEmployee_InvalidId_ThrowDbUpdateConcurrencyException()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);
            await _repository.Delete(-1, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }
    }
}
