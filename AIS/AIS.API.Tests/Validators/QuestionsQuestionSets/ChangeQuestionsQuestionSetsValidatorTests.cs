using AIS.API.Validators.QuestionsQuestionSets;
using AIS.API.ViewModels.QuestionsQuestionSets;
using Shouldly;
using Xunit;

namespace AIS.API.Tests.Validators.QuestionsQuestionSets
{
    public class ChangeQuestionsQuestionSetsValidatorTests
    {
        [Fact]
        public void Validate_ValidModel_ReturnsTrue()
        {
            var validator = new ChangeQuestionsQuestionSetsViewModelValidator();
            var model = new ChangeQuestionsQuestionSetsViewModel
            {
                QuestionSetId = 1,
                QuestionId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Validate_QuestionSetIdLessThanOne_ReturnsFalse()
        {
            var validator = new ChangeQuestionsQuestionSetsViewModelValidator();
            var model = new ChangeQuestionsQuestionSetsViewModel
            {
                QuestionSetId = -1,
                QuestionId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.QuestionSetId));
        }

        [Fact]
        public void Validate_QuestionIdLessThanOne_ReturnsFalse()
        {
            var validator = new ChangeQuestionsQuestionSetsViewModelValidator();
            var model = new ChangeQuestionsQuestionSetsViewModel
            {
                QuestionSetId = 1,
                QuestionId = -11
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.QuestionId));
        }

        [Fact]
        public void Validate_WithoutQuestionId_ReturnsFalse()
        {
            var validator = new ChangeQuestionsQuestionSetsViewModelValidator();
            var model = new ChangeQuestionsQuestionSetsViewModel
            {
                QuestionSetId = 1,
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.QuestionId));
        }

        [Fact]
        public void Validate_WithoutQuestionSetId_ReturnsFalse()
        {
            var validator = new ChangeQuestionsQuestionSetsViewModelValidator();
            var model = new ChangeQuestionsQuestionSetsViewModel
            {
                QuestionId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.QuestionSetId));
        }
    }
}
