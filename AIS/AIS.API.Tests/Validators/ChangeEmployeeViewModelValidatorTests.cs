using AIS.API.Validators;
using AIS.API.ViewModels.Employee;
using Xunit;

namespace AIS.API.Tests.Validators
{
    public class ChangeChangeEmployeeViewModelValidatorTests
    {
        [Fact]
        public void Validate_ShouldReturnTrue_WithValidModel()
        {
            var validator = new ChangeEmployeeViewModelValidator();

            var model = new ChangeEmployeeViewModel
            {
                Name = "asdasd",
                CompanyId = 1
            };

            validator.Validate(model);

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.True(result.IsValid);
        }
        
        [Fact]
        public void Validate_ShouldReturnFalse_WithInvalidModelWithoutName()
        {
            var validator = new ChangeEmployeeViewModelValidator();

            var model = new ChangeEmployeeViewModel
            {
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
            var validator = new ChangeEmployeeViewModelValidator();

            var model = new ChangeEmployeeViewModel
            {
                Name = "asdasd"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_ShouldReturnFalse_WithInvalidModelWhenCompanyIdLessThanOne()
        {
            var validator = new ChangeEmployeeViewModelValidator();

            var model = new ChangeEmployeeViewModel
            {
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
            var validator = new ChangeEmployeeViewModelValidator();

            var model = new ChangeEmployeeViewModel
            {
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
