using AIS.API.Validators.QuestionArea;
using AIS.API.ViewModels.QuestionArea;
using Shouldly;
using Xunit;

namespace AIS.API.Tests.Validators.QuestionArea
{
    public class QuestionAreaUpdateViewModelValidatorTests
    {
        [Fact]
        public void Validate_ValidModel_ReturnsTrue()
        {
            var validator = new QuestionAreaUpdateViewModelValidator();
            var model = new QuestionAreaUpdateViewModel
            {
                Name = "setsetset"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Validate_TextLengthLessThanThree_ReturnsFalse()
        {
            var validator = new QuestionAreaUpdateViewModelValidator();
            var model = new QuestionAreaUpdateViewModel
            {
                Name = "a"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.Name));
        }


        [Fact]
        public void Validate_TextEqualsNull_ReturnsFalse()
        {
            var validator = new QuestionAreaUpdateViewModelValidator();
            var model = new QuestionAreaUpdateViewModel
            {
                Name = null
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.Name));
        }
    }
}
