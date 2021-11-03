using AIS.API.Validators.QuestionSet;
using AIS.API.ViewModels.QuestionSet;
using Shouldly;
using Xunit;

namespace AIS.API.Tests.Validators.QuestionSet
{
    public class QuestionSetUpdateViewModelValidatorTests
    {
        [Fact]
        public void Validate_ValidModel_ReturnsTrue()
        {
            var validator = new QuestionSetUpdateViewModelValidator();
            var model = new QuestionSetUpdateViewModel
            {
                Name = "Okay",
                QuestionAreaId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Validate_WithoutName_ReturnsFalse()
        {
            var validator = new QuestionSetUpdateViewModelValidator();
            var model = new QuestionSetUpdateViewModel
            {
                QuestionAreaId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.Name));
        }

        [Fact]
        public void Validate_WithoutQuestionAreaId_ReturnsFalse()
        {
            var validator = new QuestionSetUpdateViewModelValidator();
            var model = new QuestionSetUpdateViewModel
            {
                Name = "Okay"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.QuestionAreaId));
        }

        [Fact]
        public void Validate_NameLengthLessThanTwo_ReturnsFalse()
        {
            var validator = new QuestionSetUpdateViewModelValidator();
            var model = new QuestionSetUpdateViewModel
            {
                QuestionAreaId = 1,
                Name = "A"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.Name));
        }

        [Fact]
        public void Validate_QuestionAreaIdLessThanOne_ReturnsFalse()
        {
            var validator = new QuestionSetUpdateViewModelValidator();
            var model = new QuestionSetUpdateViewModel
            {
                QuestionAreaId = 0,
                Name = "Okay"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.QuestionAreaId));
        }
    }
}
