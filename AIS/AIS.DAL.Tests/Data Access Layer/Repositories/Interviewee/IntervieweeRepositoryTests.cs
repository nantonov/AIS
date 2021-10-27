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
        public async Task Something()
        {
            var res = await _repository.Something().ConfigureAwait(false);
            res.ShouldBe(1);
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
            var company = new CompanyEntity
            {
                Id = 2,
                Name = "das"
            };

            await using (_context = new(_options))
            {
                _context.Interviewees.Add(model);
                _context.Companies.Add(company);

                await _context.SaveChangesAsync();

                var employee = await _repository.GetById(8, default);

                employee.ShouldNotBeNull();
                employee.ShouldBeEquivalentTo(model);
            }
        }

        [Fact]
        public async Task GetInterviewees_ValidModels_ReturnsIntervieweeEntityList()
        {
            _context = new(_options);
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

        [Fact]
        public async Task AddInterviewee_ValidModel_ReturnsIntervieweeEntity()
        {
            var model = new IntervieweeEntity()
            {
                Id = 5,
                CompanyId = 2,
                Name = "asd"
            };

            var employee = await _repository.Add(model, default);

            employee.ShouldNotBeNull();
            employee.ShouldBeEquivalentTo(model);
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

                var employee = await _repository.Update(expectedModel, default);

                employee.ShouldNotBeNull();
                employee.ShouldBeEquivalentTo(expectedModel);
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

                await _repository.Delete(employeeModel, default).ShouldNotThrowAsync();
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

                await _repository.Delete(1, default).ShouldNotThrowAsync();
            }
        }

        [Fact]
        public async Task GetIntervieweeById_InvalidId_ReturnsNull()
        {
            var model = new IntervieweeEntity
            {
                Id = 9,
                CompanyId = 21,
                Name = "asd"
            };
            var company = new CompanyEntity
            {
                Id = 21,
                Name = "dsa"
            };

            using (_context = new(_options))
            {
                _context.Interviewees.Add(model);
                _context.Companies.Add(company);

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

            await _repository.Add(model, default).ShouldThrowAsync(typeof(ArgumentNullException));
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

                await _repository.Update(expectedModel, default).ShouldThrowAsync(typeof(DbUpdateConcurrencyException));
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

            await _repository.Delete(employeeModel, default).ShouldThrowAsync(typeof(DbUpdateConcurrencyException));
        }

        [Fact]
        public async Task DeleteInterviewee_InvalidId_ThrowDbUpdateConcurrencyException()
        {
            await _repository.Delete(1, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }
    }
}
