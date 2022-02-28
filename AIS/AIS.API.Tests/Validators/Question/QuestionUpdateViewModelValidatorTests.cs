using AIS.API.Validators.Question;
using AIS.API.ViewModels.Question;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AIS.API.Tests.Validators.Question
{
    public class QuestionUpdateViewModelValidatorTests
    {
        [Fact]
        public void Validate_ValidModel_ReturnsTrue()
        {
            var validator = new QuestionUpdateViewModelValidator();
            var model = new QuestionUpdateViewModel
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
            var validator = new QuestionUpdateViewModelValidator();
            var model = new QuestionUpdateViewModel
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
            var validator = new QuestionUpdateViewModelValidator();
            var model = new QuestionUpdateViewModel
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
