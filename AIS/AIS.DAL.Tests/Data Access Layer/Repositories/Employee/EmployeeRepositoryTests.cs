using AIS.DAL.Entities;
using AIS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AIS.DAL.Tests.Data_Access_Layer.Repositories.Employee
{
    public class EmployeeRepositoryTests
    {
        private readonly DbContextOptions<DatabaseContext> _options;
        private DatabaseContext _context;
        private readonly EmployeeRepository _repository;

        public EmployeeRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "EmployeeDataBase")
                .Options;
            _context = new(_options);
            _repository = new(_context);
        }

        [Fact]
        public async Task GetEmployeeById_ValidId_ReturnsEmployeeEntity()
        {
            var model = new EmployeeEntity
            {
                Id = 8,
                CompanyId = 2,
                Name = "asd"
            };

            using (_context = new(_options))
            {
                _context.Employees.Add(model);

                await _context.SaveChangesAsync();

                var employee = _repository.GetById(8, default);

                await employee.ShouldNotBeNull();
                employee.Result.ShouldBeEquivalentTo(model);
            }
        }

        [Fact]
        public async Task GetEmployees_ValidModels_ReturnsEmployeeEntity()
        {
            using (_context = new(_options))
            {
                _context.Employees.Add(new EmployeeEntity
                {
                    Id = 6,
                    CompanyId = 1,
                    Name = "asd"
                });

                _context.Employees.Add(new EmployeeEntity
                {
                    Id = 7,
                    CompanyId = 1,
                    Name = "dsa"
                });

                _context.Companies.Add(new CompanyEntity
                {
                    Id = 1,
                    Name = "asd"
                });

                await _context.SaveChangesAsync();

                var employee = await _repository.Get(default);

                employee.ShouldNotBeEmpty();
            }
        }

        [Fact]
        public async Task AddEmployee_ValidModel_ReturnsEmployeeEntity()
        {
            var model = new EmployeeEntity()
            {
                Id = 5,
                CompanyId = 2,
                Name = "asd"
            };

            using (_context = new(_options))
            {
                var employee = _repository.Add(model, default);

                await employee.ShouldNotBeNull();
                employee.Result.ShouldBeEquivalentTo(model);
            }
        }

        [Fact]
        public async Task UpdateEmployee_ValidModel_ReturnsEmployeeEntity()
        {
            var expectedModel = new EmployeeEntity
            {
                Id = 14,
                CompanyId = 6,
                Name = "asd"
            };

            var addedModel = new EmployeeEntity
            {
                Id = 14,
                CompanyId = 6,
                Name = "asd"
            };

            using (_context = new(_options))
            {
                await _context.Employees.AddAsync(addedModel);
                await _context.SaveChangesAsync();

                await _context.Companies.AddAsync(new CompanyEntity
                {
                    Id = 3,
                    Name = "asd"
                });

                await _context.SaveChangesAsync();

                var employee = _repository.Update(expectedModel, default);

                await employee.ShouldNotBeNull();
                employee.Result.ShouldBeEquivalentTo(expectedModel);
            }
        }

        [Fact]
        public async Task GetEmployeesByPredicate_ValidPredicate_ReturnsEmployeeEnitityList()
        {
            var model = new[] {
                    new EmployeeEntity
                    {
                        Id = 13,
                        CompanyId = 5,
                        Name = "asd"
                    }
                };

            using (_context = new(_options))
            {
                _context.Companies.Add(new CompanyEntity
                {
                    Id = 5,
                    Name = "asd"
                });

                _context.Employees.Add(model[0]);

                await _context.SaveChangesAsync();

                var employee = _repository.Get(x => x.Id == model[0].Id, default);

                employee.ShouldNotBeNull();
            }
        }

        [Fact]
        public async Task DeleteEmployee_ValidModel_NotThrow()
        {
            var employeeModel = new EmployeeEntity
            {
                Id = 2,
                CompanyId = 2,
                Name = "asd",
            };

            using (_context = new(_options))
            {
                _context.Employees.Add(employeeModel);

                await _context.SaveChangesAsync();

                var employee = _repository.Delete(employeeModel, default);

                await employee.ShouldNotThrowAsync();
            }
        }

        [Fact]
        public async Task DeleteEmployee_ValidId_NotThrow()
        {
            using (_context = new(_options))
            {
                _context.Employees.Add(new EmployeeEntity
                {
                    Id = 1,
                    CompanyId = 2,
                    Name = "asd"
                });

                await _context.SaveChangesAsync();

                var employee = _repository.Delete(1, default);

                await employee.ShouldNotThrowAsync();
            }
        }

        [Fact]
        public async Task GetEmployeeById_InvalidId_ReturnsNull()
        {
            var model = new EmployeeEntity
            {
                Id = 9,
                CompanyId = 2,
                Name = "asd"
            };

            using (_context = new(_options))
            {
                _context.Employees.Add(model);

                await _context.SaveChangesAsync();

                var employee = await _repository.GetById(-8, default);

                employee.ShouldBeNull();
            }
        }

        [Fact]
        public async Task GetEmployees_NoModels_ReturnsEmptyEmployeeEntityList()
        {
            using (_context = new(_options))
            {
                await _context.Database.EnsureDeletedAsync();

                var employee = await _repository.Get(default);

                employee.ShouldBeEmpty();
            }
        }

        [Fact]
        public async Task AddEmployee_InvalidModel_ThrowArgumentNullException()
        {
            var model = (EmployeeEntity)null;

            var employee = _repository.Add(model, default);

            await employee.ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task UpdateEmployee_InvalidModel_ThrowDbUpdateConcurrencyException()
        {
            var expectedModel = new EmployeeEntity
            {
                Name = "Name"
            };

            var addedModel = new EmployeeEntity
            {
                Id = 4,
                CompanyId = 3,
                Name = "asd"
            };

            using (_context = new(_options))
            {
                await _context.Employees.AddAsync(addedModel);
                await _context.SaveChangesAsync();

                var employee = _repository.Update(expectedModel, default);

                await employee.ShouldThrowAsync(typeof(DbUpdateConcurrencyException));
            }
        }

        [Fact]
        public void GetEmployeesByPredicate_ValidPredicate_ReturnsEmptyEmployeeEntityList()
        {
            using (_context = new(_options))
            {
                var employee = _repository.Get(x => x.Id == -1, default);

                employee.ShouldBeEmpty();
            }
        }

        [Fact]
        public async Task DeleteEmployee_InvalidModel_ThrowNullArgumentException()
        {
            var employeeModel = new EmployeeEntity
            {
                Id = -1
            };

            var employee = _repository.Delete(employeeModel, default);

            await employee.ShouldThrowAsync(typeof(DbUpdateConcurrencyException));
        }

        [Fact]
        public async Task DeleteEmployee_InvalidId_ThrowDbUpdateConcurrencyException()
        {
            var employee = _repository.Delete(1, default);

            await employee.ShouldThrowAsync(typeof(ArgumentNullException));
        }
    }
}
