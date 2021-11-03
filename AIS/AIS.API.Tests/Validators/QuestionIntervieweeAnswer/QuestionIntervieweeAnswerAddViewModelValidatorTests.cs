using AIS.API.Validators.QuestionIntervieweeAnswer;
using AIS.API.ViewModels.QuestionIntervieweeAnswer;
using Shouldly;
using Xunit;

namespace AIS.API.Tests.Validators.QuestionIntervieweeAnswer
{
    public class QuestionIntervieweeAnswerAddViewModelValidatorTests
    {
        [Fact]
        public void Validate_ValidModel_ReturnsTrue()
        {
            var validator = new QuestionIntervieweeAnswerAddViewModelValidator();
            var model = new QuestionIntervieweeAnswerAddViewModel
            {
                Mark = 5,
                QuestionId = 1,
                Text = "asd",
                TrueAnswerId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Validate_WithoutMark_ReturnsFalse()
        {
            var validator = new QuestionIntervieweeAnswerAddViewModelValidator();
            var model = new QuestionIntervieweeAnswerAddViewModel
            {
                QuestionId = 1,
                Text = "asd",
                TrueAnswerId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.Mark));
        }

        [Fact]
        public void Validate_WithoutQuestionId_ReturnsFalse()
        {
            var validator = new QuestionIntervieweeAnswerAddViewModelValidator();
            var model = new QuestionIntervieweeAnswerAddViewModel
            {
                Mark = 1,
                Text = "asd",
                TrueAnswerId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.QuestionId));
        }

        [Fact]
        public void Validate_WithoutTrueAnswer_ReturnsFalse()
        {
            var validator = new QuestionIntervieweeAnswerAddViewModelValidator();
            var model = new QuestionIntervieweeAnswerAddViewModel
            {
                QuestionId = 1,
                Text = "asd",
                Mark = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.TrueAnswerId));
        }

        [Fact]
        public void Validate_MarkLessThanZero_ReturnsFalse()
        {
            var validator = new QuestionIntervieweeAnswerAddViewModelValidator();
            var model = new QuestionIntervieweeAnswerAddViewModel
            {
                Mark = -1,
                QuestionId = 1,
                Text = "asd",
                TrueAnswerId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.Mark));
        }

        [Fact]
        public void Validate_QuestionIdLessThanOne_ReturnsFalse()
        {
            var validator = new QuestionIntervieweeAnswerAddViewModelValidator();
            var model = new QuestionIntervieweeAnswerAddViewModel
            {
                Mark = 1,
                QuestionId = 0,
                Text = "asd",
                TrueAnswerId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.QuestionId));
        }

        [Fact]
        public void Validate_TrueAnswerIdLessThanOne_ReturnsFalse()
        {
            var validator = new QuestionIntervieweeAnswerAddViewModelValidator();
            var model = new QuestionIntervieweeAnswerAddViewModel
            {
                Mark = 1,
                QuestionId = 1,
                Text = "asd",
                TrueAnswerId = -1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.TrueAnswerId));
        }

        [Fact]
        public void Validate_MarkGreaterThanTen_ReturnsFalse()
        {
            var validator = new QuestionIntervieweeAnswerAddViewModelValidator();
            var model = new QuestionIntervieweeAnswerAddViewModel
            {
                Mark = 11,
                QuestionId = 1,
                Text = "asd",
                TrueAnswerId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.Mark));
        }
    }
}
