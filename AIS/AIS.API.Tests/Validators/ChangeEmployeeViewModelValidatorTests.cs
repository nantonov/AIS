using System.Linq;
using AIS.API.Validators;
using AIS.API.ViewModels.Employee;
using Xunit;

namespace AIS.API.Tests.Validators
{
    public class ChangeChangeEmployeeViewModelValidatorTests
    {
        [Fact]
        public void Validate_ValidModel_ReturnsTrue()
        {
            var validator = new ChangeEmployeeViewModelValidator();

            var model = new ChangeEmployeeViewModel
            {
                Name = "asdasd",
                CompanyId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_ModelWithoutName_ReturnsFalse()
        {
            var validator = new ChangeEmployeeViewModelValidator();

            var model = new ChangeEmployeeViewModel
            {
                CompanyId = 1
            };

            // Act
            //var result = validator.Validate(model);

            var result = validator.Validate(model);

            // Assert
            Assert.NotEqual(0, result.Errors.Count);
            Assert.True(result.Errors.Any(x => x.PropertyName == nameof(model.Name)));
        }

        [Fact]
        public void Validate_ModelWithoutCompanyId_ReturnsFalse()
        {
            var validator = new ChangeEmployeeViewModelValidator();

            var model = new ChangeEmployeeViewModel
            {
                Name = "asdasd"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.NotEqual(0, result.Errors.Count);
            Assert.True(result.Errors.Any(x => x.PropertyName == nameof(model.CompanyId)));
        }

        [Fact]
        public void Validate_CompanyIdLessThanOne_ReturnsFalse()
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
            Assert.NotEqual(0, result.Errors.Count);
            Assert.True(result.Errors.Any(x => x.PropertyName == nameof(model.CompanyId)));
        }

        [Fact]
        public void Validate_NameLengthLessThanThree_ReturnsFalse()
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
            Assert.NotEqual(0, result.Errors.Count);
            Assert.True(result.Errors.Any(x => x.PropertyName == nameof(model.Name)));
        }
    }
}
