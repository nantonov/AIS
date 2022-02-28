using AIS.API.Validators.Question;
using AIS.API.ViewModels.Question;
using Shouldly;
using Xunit;

namespace AIS.API.Tests.Validators.Question
{
    public class QuestionAddViewModelValidatorTests
    {
        [Fact]
        public void Validate_ValidModel_ReturnsTrue()
        {
            var validator = new QuestionAddViewModelValidator();
            var model = new QuestionAddViewModel
            {
                Text = "asdasdasdasd"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Validate_ModelWithoutText_ReturnsFalse()
        {
            var validator = new QuestionAddViewModelValidator();
            var model = new QuestionAddViewModel
            {
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.Text));
        }

        [Fact]
        public void Validate_TextLengthLessThanTen_ReturnsFalse()
        {
            var validator = new QuestionAddViewModelValidator();
            var model = new QuestionAddViewModel
            {
                Text = "1"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.Text));
        }

        [Fact]
        public void Validate_TextEqualsNull_ReturnsFalse()
        {
            var validator = new QuestionAddViewModelValidator();
            var model = new QuestionAddViewModel
            {
                Text = null
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.Text));
        }
    }
}
