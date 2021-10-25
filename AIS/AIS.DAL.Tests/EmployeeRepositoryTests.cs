using AIS.DAL.Entities;
using AIS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace AIS.DAL.Tests
{
    public class EmployeeRepositoryTests
    {
        [Fact]
        public async Task GetUser_ReturnUser()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "EmployeeDataBase")
                .Options;

            var context = new DatabaseContext(options);

            using (var add = new DatabaseContext(options))
            {
                add.Employees.Add(new EmployeeEntity
                {
                    Id = 12,
                    CompanyId = 2,
                    Name = "asd"
                });

                add.Employees.Add(new EmployeeEntity
                {
                    Id = 15,
                    CompanyId = 3,
                    Name = "dsa"
                });

                await add.SaveChangesAsync();
            }

            var repository = new EmployeeRepository(context);
            var employee = repository.GetById(12, default);

            await employee.ShouldNotBeNull();
            employee.Result.Name.ShouldBeEquivalentTo("asd");
        }

        [Fact]
        public async Task GetInterviewee_ReturnUser()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "EmployeeDataBase")
                .Options;

            var context = new DatabaseContext(options);

            using (var add = new DatabaseContext(options))
            {
                add.Interviewees.Add(new IntervieweeEntity
                {
                    Id = 12,
                    CompanyId = 2,
                    Name = "asd",
                    AppliesFor = "qwe"
                });

                add.Interviewees.Add(new IntervieweeEntity
                {
                    Id = 15,
                    CompanyId = 3,
                    Name = "dsa",
                    AppliesFor = "ewq"
                });

                await add.SaveChangesAsync();
            }

            var repository = new IntervieweeRepository(context);
            var employee = repository.GetById(12, default);

            await employee.ShouldNotBeNull();
            employee.Result.Name.ShouldBeEquivalentTo("asd");
        }
    }
}
