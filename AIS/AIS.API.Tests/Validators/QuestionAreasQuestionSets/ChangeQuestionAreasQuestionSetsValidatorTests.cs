using AIS.API.Validators.QuestionAreasQuestionSets;
using AIS.API.ViewModels.QuestionAreasQuestionSets;
using Shouldly;
using Xunit;

namespace AIS.API.Tests.Validators.QuestionAreasQuestionSets
{
    public class ChangeQuestionAreasQuestionSetsValidatorTests
    {
        [Fact]
        public void Validate_ValidModel_ReturnsTrue()
        {
            var validator = new ChangeQuestionAreasQuestionSetsViewModelValidator();
            var model = new ChangeQuestionAreasQuestionSetsViewModel
            {
                QuestionSetId = 1,
                QuestionAreaId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Validate_QuestionSetIdLessThanOne_ReturnsFalse()
        {
            var validator = new ChangeQuestionAreasQuestionSetsViewModelValidator();
            var model = new ChangeQuestionAreasQuestionSetsViewModel
            {
                QuestionSetId = -10,
                QuestionAreaId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.QuestionSetId));
        }

        [Fact]
        public void Validate_QuestionAreaIdLessThanOne_ReturnsFalse()
        {
            var validator = new ChangeQuestionAreasQuestionSetsViewModelValidator();
            var model = new ChangeQuestionAreasQuestionSetsViewModel
            {
                QuestionSetId = 1,
                QuestionAreaId = -1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.QuestionAreaId));
        }

        [Fact]
        public void Validate_WithoutQuestionAreaId_ReturnsFalse()
        {
            var validator = new ChangeQuestionAreasQuestionSetsViewModelValidator();
            var model = new ChangeQuestionAreasQuestionSetsViewModel
            {
                QuestionSetId = 1,
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.QuestionAreaId));
        }

        [Fact]
        public void Validate_WithoutQuestionSetId_ReturnsFalse()
        {
            var validator = new ChangeQuestionAreasQuestionSetsViewModelValidator();
            var model = new ChangeQuestionAreasQuestionSetsViewModel
            {
                QuestionAreaId = 1,
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.QuestionSetId));
        }
    }
}
