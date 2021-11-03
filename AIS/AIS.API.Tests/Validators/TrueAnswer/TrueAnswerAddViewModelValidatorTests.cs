using AIS.API.Validators.TrueAnswer;
using AIS.API.ViewModels.TrueAnswer;
using Shouldly;
using Xunit;

namespace AIS.API.Tests.Validators.TrueAnswer
{
    public class TrueAnswerAddViewModelValidatorTests
    {
        [Fact]
        public void Validate_ValidModel_ReturnsTrue()
        {
            var validator = new TrueAnswerAddViewModelValidator();
            var model = new TrueAnswerAddViewModel
            {
                QuestionId = 1,
                Text = "asdasdasdasd"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Validate_WithoutQuestionId_ReturnsFalse()
        {
            var validator = new TrueAnswerAddViewModelValidator();
            var model = new TrueAnswerAddViewModel
            {
                Text = "asdqweasdqwe"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.QuestionId));
        }

        [Fact]
        public void Validate_TextEqualsNull_ReturnsFalse()
        {
            var validator = new TrueAnswerAddViewModelValidator();
            var model = new TrueAnswerAddViewModel
            {
                QuestionId = 1,
                Text = null
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.Text));
        }

        [Fact]
        public void Validate_QuestionIdLessThanOne_ReturnsFalse()
        {
            var validator = new TrueAnswerAddViewModelValidator();
            var model = new TrueAnswerAddViewModel
            {
                QuestionId = 0,
                Text = "zxcasdqwe123"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.QuestionId));
        }

        [Fact]
        public void Validate_TextLengthLessThanTen_ReturnsFalse()
        {
            var validator = new TrueAnswerAddViewModelValidator();
            var model = new TrueAnswerAddViewModel
            {
                QuestionId = 1,
                Text = "123"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.Text));
        }
    }
}
