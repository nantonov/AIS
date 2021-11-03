using AIS.API.Validators.TrueAnswer;
using AIS.API.ViewModels.TrueAnswer;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AIS.API.Tests.Validators.TrueAnswer
{
    public class TrueAnswerUpdateViewModelValidatorTests
    {
        [Fact]
        public void Validate_ValidModel_ReturnsTrue()
        {
            var validator = new TrueAnswerUpdateViewModelValidator();
            var model = new TrueAnswerUpdateViewModel
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
            var validator = new TrueAnswerUpdateViewModelValidator();
            var model = new TrueAnswerUpdateViewModel
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
            var validator = new TrueAnswerUpdateViewModelValidator();
            var model = new TrueAnswerUpdateViewModel
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
            var validator = new TrueAnswerUpdateViewModelValidator();
            var model = new TrueAnswerUpdateViewModel
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
            var validator = new TrueAnswerUpdateViewModelValidator();
            var model = new TrueAnswerUpdateViewModel
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
