using AIS.DAL;
using AIS.DAL.Entities;
using AIS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace AIS.BLL.Tests
{
    public class test
    {
        [Fact]
        public async Task GetInterviewee_ReturnUser()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "EmployeeDataBase")
                .Options;

            var context = new DatabaseContext(options);

            using (var add = new DatabaseContext(options))
            {
                add.Companies.Add(new CompanyEntity
                {
                    Id = 13,
                    Name = "asd"
                });

                add.Companies.Add(new CompanyEntity
                {
                    Id = 16,
                    Name = "dsa"
                });

                await add.SaveChangesAsync();
            }

            var repository = new CompanyRepository(context);
            var employee = repository.GetById(13, default);

            employee.Result.ShouldNotBeNull();
            employee.Result.Name.ShouldBeEquivalentTo("asd");
        }

        [Fact]
        public async Task GetInterviewee_ReturnNull()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "EmployeeDataBase")
                .Options;

            var context = new DatabaseContext(options);

            using (var add = new DatabaseContext(options))
            {
                add.Companies.Add(new CompanyEntity
                {
                    Id = 12,
                    Name = "asd"
                });

                add.Companies.Add(new CompanyEntity
                {
                    Id = 15,
                    Name = "dsa"
                });

                await add.SaveChangesAsync();
            }

            var repository = new CompanyRepository(context);
            var employee = repository.GetById(14, default);

            employee.Result.ShouldBeNull();
        }
    }
}
