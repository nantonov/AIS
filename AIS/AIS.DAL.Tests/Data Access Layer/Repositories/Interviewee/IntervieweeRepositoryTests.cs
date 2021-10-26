using AIS.DAL.Entities;
using AIS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AIS.DAL.Tests.Data_Access_Layer.Repositories.Interviewee
{
    public class IntervieweeRepositoryTests
    {
        private readonly DbContextOptions<DatabaseContext> _options;
        private DatabaseContext _context;
        private readonly IntervieweeRepository _repository;

        public IntervieweeRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "IntervieweeDataBase")
                .Options;
            _context = new(_options);
            _repository = new(_context);
        }

        [Fact]
        public async Task GetIntervieweeById_ValidId_ReturnsIntervieweeEntity()
        {
            var model = new IntervieweeEntity
            {
                Id = 8,
                CompanyId = 2,
                Name = "asd"
            };

            using (_context = new(_options))
            {
                _context.Interviewees.Add(model);

                await _context.SaveChangesAsync();

                var employee = _repository.GetById(8, default);

                await employee.ShouldNotBeNull();
                employee.Result.ShouldBeEquivalentTo(model);
            }
        }

        [Fact]
        public async Task GetInterviewees_ValidModels_ReturnsIntervieweeEntityList()
        {
            using (_context = new(_options))
            {
                _context.Interviewees.Add(new IntervieweeEntity
                {
                    Id = 6,
                    CompanyId = 1,
                    Name = "asd"
                });

                _context.Interviewees.Add(new IntervieweeEntity
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

                employee.ShouldNotBeNull();
            }
        }

        [Fact]
        public async Task AddInterviewee_ValidModel_ReturnsIntervieweeEntity()
        {
            var model = new IntervieweeEntity()
            {
                Id = 5,
                CompanyId = 2,
                Name = "asd"
            };

            var employee = _repository.Add(model, default);

            await employee.ShouldNotBeNull();
            employee.Result.ShouldBeEquivalentTo(model);
        }

        [Fact]
        public async Task UpdateInterviewee_ValidModel_ReturnsIntervieweeEntity()
        {
            var expectedModel = new IntervieweeEntity
            {
                Id = 14,
                CompanyId = 6,
                Name = "asd"
            };

            var addedModel = new IntervieweeEntity
            {
                Id = 14,
                CompanyId = 6,
                Name = "asd"
            };

            using (_context = new(_options))
            {
                await _context.Interviewees.AddAsync(addedModel);
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
        public async Task GetIntervieweesByPredicate_ValidPredicate_ReturnsIntervieweeEntityList()
        {
            var model = new[] {
                    new IntervieweeEntity
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

                _context.Interviewees.Add(model[0]);

                await _context.SaveChangesAsync();

                var employee = _repository.Get(x => x.Id == model[0].Id, default);

                employee.ShouldNotBeNull();
            }
        }

        [Fact]
        public async Task DeleteInterviewee_ValidModel_NotThrow()
        {
            var employeeModel = new IntervieweeEntity
            {
                Id = 2,
                CompanyId = 2,
                Name = "asd",
            };

            using (_context = new(_options))
            {
                _context.Interviewees.Add(employeeModel);

                await _context.SaveChangesAsync();

                var employee = _repository.Delete(employeeModel, default);

                await employee.ShouldNotThrowAsync();
            }
        }

        [Fact]
        public async Task DeleteInterviewee_ValidId_NotThrow()
        {
            using (_context = new(_options))
            {
                _context.Interviewees.Add(new IntervieweeEntity
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
        public async Task GetIntervieweeById_InvalidId_ReturnsNull()
        {
            var model = new IntervieweeEntity
            {
                Id = 9,
                CompanyId = 2,
                Name = "asd"
            };

            using (_context = new(_options))
            {
                _context.Interviewees.Add(model);

                await _context.SaveChangesAsync();

                var employee = await _repository.GetById(-8, default);

                employee.ShouldBeNull();
            }
        }

        [Fact]
        public async Task GetInterviewees_NoModels_ReturnsEmptyIntervieweeEntityList()
        {
            using (_context = new(_options))
            {
                var employee = await _repository.Get(default);

                employee.ShouldBeEmpty();
            }
        }

        [Fact]
        public async Task AddInterviewee_InvalidModel_ThrowArgumentNullException()
        {
            var model = (IntervieweeEntity)null;

            var employee = _repository.Add(model, default);

            await employee.ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task UpdateInterviewee_InvalidModel_ThrowDbUpdateConcurrencyException()
        {
            var expectedModel = new IntervieweeEntity
            {
                Name = "Name"
            };

            var addedModel = new IntervieweeEntity
            {
                Id = 4,
                CompanyId = 3,
                Name = "asd"
            };

            using (_context = new(_options))
            {
                await _context.Interviewees.AddAsync(addedModel);
                await _context.SaveChangesAsync();

                var employee = _repository.Update(expectedModel, default);

                await employee.ShouldThrowAsync(typeof(DbUpdateConcurrencyException));
            }
        }

        [Fact]
        public void GetIntervieweesByPredicate_ValidPredicate_ReturnsEmptyIntervieweeEntityList()
        {
            using (_context = new(_options))
            {
                var employee = _repository.Get(x => x.Id == -1, default);

                employee.ShouldBeEmpty();
            }
        }

        [Fact]
        public async Task DeleteInterviewee_InvalidModel_ThrowNullArgumentException()
        {
            var employeeModel = new IntervieweeEntity
            {
                Id = -1
            };

            var employee = _repository.Delete(employeeModel, default);

            await employee.ShouldThrowAsync(typeof(DbUpdateConcurrencyException));
        }

        [Fact]
        public async Task DeleteInterviewee_InvalidId_ThrowDbUpdateConcurrencyException()
        {
            var employee = _repository.Delete(1, default);

            await employee.ShouldThrowAsync(typeof(ArgumentNullException));
        }
    }
}
