using AIS.API.Validators;
using AIS.API.ViewModels.Employee;
using Xunit;

namespace AIS.API.Tests.Validators
{
    public class EmployeeViewModelValidatorTests
    {
        [Fact]
        public void Validate_ShouldReturnTrue_WithValidModel()
        {
            var validator = new EmployeeViewModelValidator();

            var model = new EmployeeViewModel
            {
                Id = 2,
                Name = "asdasd",
                CompanyId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_ShouldReturnFalse_WithInvalidModelWithoutId()
        {
            var validator = new EmployeeViewModelValidator();

            var model = new EmployeeViewModel
            {
                Name = "asdasd",
                CompanyId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_ShouldReturnFalse_WithInvalidModelWithoutName()
        {
            var validator = new EmployeeViewModelValidator();

            var model = new EmployeeViewModel
            {
                Id = 2,
                CompanyId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_ShouldReturnFalse_WithInvalidModelWithoutCompanyId()
        {
            var validator = new EmployeeViewModelValidator();

            var model = new EmployeeViewModel
            {
                Id = 2,
                Name = "asdasd"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_ShouldReturnFalse_WithInvalidModelWhenIdLessThanOne()
        {
            var validator = new EmployeeViewModelValidator();

            var model = new EmployeeViewModel
            {
                Id = 0,
                Name = "asdasd",
                CompanyId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_ShouldReturnFalse_WithInvalidModelWhenCompanyIdLessThanOne()
        {
            var validator = new EmployeeViewModelValidator();

            var model = new EmployeeViewModel
            {
                Id = 2,
                Name = "asdasd",
                CompanyId = 0
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_ShouldReturnFalse_WithInvalidModelWhenNameLengthLessThanThree()
        {
            var validator = new EmployeeViewModelValidator();

            var model = new EmployeeViewModel
            {
                Id = 2,
                Name = "as",
                CompanyId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
