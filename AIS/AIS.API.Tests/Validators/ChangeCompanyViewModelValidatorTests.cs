using AIS.API.Validators;
using AIS.API.ViewModels.Company;
using Shouldly;
using Xunit;

namespace AIS.API.Tests.Validators
{
    public class ChangeCompanyViewModelValidatorTests
    {
        [Fact]
        public void Validate_ValidModel_ReturnsTrue()
        {
            var validator = new ChangeCompanyViewModelValidator();

            var model = new ChangeCompanyViewModel
            {
                Name = "asdasd"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Validate_ModelWithoutName_ReturnsFalse()
        {
            var validator = new ChangeCompanyViewModelValidator();

            var model = new ChangeCompanyViewModel();

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.Name));
        }

        [Fact]
        public void Validate_NameLengthLessThanThree_ReturnsFalse()
        {
            var validator = new ChangeCompanyViewModelValidator();

            var model = new ChangeCompanyViewModel
            {
                Name = "as"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.Name));
        }
    }
}
