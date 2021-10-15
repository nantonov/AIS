using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AIS.BLL.Tests.Business_Logic_Layer.Servuces
{
    public class EmployeeServiceTests
    {
        [Fact]
        public async Task Get_WhenServiceHasData_ShouldReturnValidModel()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var expected = new []
            {
                new Employee() { Id = 3, Name = "Bob" },
                new Employee() { Id = 4, Name = "Did" }
            };

            mocker.Setup<IGenericService<Employee>, Task<IEnumerable<Employee>>>(setup => setup.Get()).ReturnsAsync(expected);

            var service = mocker.Get<IGenericService<Employee>>();

            // Act
            var actual = await service.Get();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Add_WhenServiceHasData_ShouldReturnValidModel()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var expected = new Employee()
            {
                Id = 3,
                Name = "Bob"
            };

            mocker.Setup<IGenericService<Employee>, Task<Employee>>(setup => setup.Add(expected)).ReturnsAsync(expected);

            var service = mocker.Get<IGenericService<Employee>>();

            // Act
            var actual = await service?.Add(expected);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_WhenServiceHasData_ShouldReturnValidModel()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var model = new Employee()
            {
                Id = 3,
                Name = "Bob"
            };

            mocker.Setup<IGenericService<Employee>, Task>(setup => setup.Delete(model));

            var service = mocker.Get<IGenericService<Employee>>();

            // Act
            Action act = () => service.Delete(model);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public async Task Update_WhenServiceHasData_ShouldReturnValidModel()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var expected = new Employee()
            {
                Id = 3,
                Name = "Bob"
            };

            mocker.Setup<IGenericService<Employee>, Task<Employee>>(setup => setup.Put(expected)).ReturnsAsync(expected);

            var service = mocker.Get<IGenericService<Employee>>();

            // Act
            var actual = await service.Put(expected);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
