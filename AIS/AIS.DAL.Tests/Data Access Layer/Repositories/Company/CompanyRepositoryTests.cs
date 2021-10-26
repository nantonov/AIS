using AIS.DAL.Entities;
using AIS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AIS.DAL.Tests.Data_Access_Layer.Repositories.Company
{
    public class CompanyRepositoryTests
    {
        private readonly DbContextOptions<DatabaseContext> _options;
        private DatabaseContext _context;
        private readonly CompanyRepository _repository;

        public CompanyRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "CompanyDataBase")
                .Options;
            _context = new(_options);
            _repository = new(_context);
        }

        [Fact]
        public async Task GetCompanyById_ValidId_ReturnsCompanyEntity()
        {
            var model = new CompanyEntity
            {
                Id = 8,
                Name = "asd"
            };

            using (_context = new(_options))
            {
                _context.Companies.Add(model);

                await _context.SaveChangesAsync();

                var employee = _repository.GetById(8, default);

                await employee.ShouldNotBeNull();
                employee.Result.ShouldBeEquivalentTo(model);
            }
        }

        [Fact]
        public async Task GetCompanies_ValidModels_ReturnsCompanyEntityList()
        {
            using (_context = new(_options))
            {
                _context.Companies.Add(new CompanyEntity
                {
                    Id = 6,
                    Name = "asd"
                });

                _context.Companies.Add(new CompanyEntity
                {
                    Id = 7,
                    Name = "dsa"
                });

                await _context.SaveChangesAsync();

                var employee = await _repository.Get(default);

                employee.ShouldNotBeNull();
            }
        }

        [Fact]
        public async Task AddCompany_ValidModel_ReturnsCompanyEntity()
        {
            var model = new CompanyEntity()
            {
                Id = 10,
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
        public async Task UpdateCompany_ValidModel_ReturnsCompanyEntity()
        {
            var expectedModel = new CompanyEntity
            {
                Id = 14,
                Name = "asd"
            };

            var addedModel = new CompanyEntity
            {
                Id = 14,
                Name = "asd"
            };

            using (_context = new(_options))
            {
                await _context.Companies.AddAsync(addedModel);
                await _context.SaveChangesAsync();

                var employee = _repository.Update(expectedModel, default);

                await employee.ShouldNotBeNull();
                employee.Result.ShouldBeEquivalentTo(expectedModel);
            }
        }

        [Fact]
        public async Task GetCompaniesByPredicate_ValidPredicate_ReturnsCompanyEntityList()
        {
            var model = new[] {
                    new CompanyEntity
                    {
                        Id = 13,
                        Name = "asd"
                    }
                };

            using (_context = new(_options))
            {
                _context.Companies.Add(model[0]);

                await _context.SaveChangesAsync();

                var employee = _repository.Get(x => x.Id == model[0].Id, default);

                employee.ShouldNotBeNull();
            }
        }

        [Fact]
        public async Task DeleteCompany_ValidModel_NotThrow()
        {
            var employeeModel = new CompanyEntity
            {
                Id = 11,
                Name = "asd",
            };

            using (_context = new(_options))
            {
                _context.Companies.Add(employeeModel);

                await _context.SaveChangesAsync();

                var employee = _repository.Delete(employeeModel, default);

                await employee.ShouldNotThrowAsync();
            }
        }

        [Fact]
        public async Task DeleteCompany_ValidId_NotThrow()
        {
            using (_context = new(_options))
            {
                _context.Companies.Add(new CompanyEntity
                {
                    Id = 1,
                    Name = "asd"
                });

                await _context.SaveChangesAsync();

                var employee = _repository.Delete(1, default);

                await employee.ShouldNotThrowAsync();
            }
        }

        [Fact]
        public async Task GetCompanyById_InvalidId_ReturnsNull()
        {
            var model = new CompanyEntity
            {
                Id = 9,
                Name = "asd"
            };

            using (_context = new(_options))
            {
                _context.Companies.Add(model);

                await _context.SaveChangesAsync();

                var employee = await _repository.GetById(-8, default);

                employee.ShouldBeNull();
            }
        }

        [Fact]
        public async Task GetCompanies_NoModels_ReturnsEmptyCompanyEntityList()
        {
            using (_context = new(_options))
            {
                var employee = await _repository.Get(default);

                employee.ShouldBeEmpty();
            }
        }

        [Fact]
        public async Task AddCompany_InvalidModel_ThrowArgumentNullException()
        {
            using (_context = new(_options))
            {
                var model = (CompanyEntity)null;

                var employee = _repository.Add(model, default);

                await employee.ShouldThrowAsync(typeof(ArgumentNullException));
            }
        }

        [Fact]
        public async Task UpdateCompany_InvalidModel_ThrowDbUpdateConcurrencyException()
        {
            var expectedModel = new CompanyEntity
            {
                Name = "Name"
            };

            var addedModel = new CompanyEntity
            {
                Id = 4,
                Name = "asd"
            };

            using (_context = new(_options))
            {
                await _context.Companies.AddAsync(addedModel);
                await _context.SaveChangesAsync();

                var employee = _repository.Update(expectedModel, default);

                await employee.ShouldThrowAsync(typeof(DbUpdateConcurrencyException));
            }
        }

        [Fact]
        public void GetCompaniesByPredicate_ValidPredicate_ReturnsEmptyCompanyEntityList()
        {
            using (_context = new(_options))
            {
                var employee = _repository.Get(x => x.Id == -1, default);

                employee.ShouldBeEmpty();
            }
        }

        [Fact]
        public async Task DeleteCompany_InvalidModel_ThrowNullArgumentException()
        {
            var employeeModel = new CompanyEntity
            {
                Id = -1
            };

            var employee = _repository.Delete(employeeModel, default);

            await employee.ShouldThrowAsync(typeof(DbUpdateConcurrencyException));
        }

        [Fact]
        public async Task DeleteCompany_InvalidId_ThrowDbUpdateConcurrencyException()
        {
            var employee = _repository.Delete(1, default);

            await employee.ShouldThrowAsync(typeof(ArgumentNullException));
        }
    }
}
