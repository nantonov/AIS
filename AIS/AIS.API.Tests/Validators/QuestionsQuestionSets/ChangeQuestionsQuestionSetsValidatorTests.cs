using AIS.API.Tests.Controllers.ViewModels;
using AIS.API.Validators.QuestionsQuestionSets;
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
            var model = ValidQuestionsQuestionSetsViewModels.questionsQuestionSetsViewModelValid;

            // Act
            var result = validator.Validate(model);

            // Assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Validate_QuestionSetIdLessThanOne_ReturnsFalse()
        {
            var validator = new ChangeQuestionsQuestionSetsViewModelValidator();
            var model = ValidQuestionsQuestionSetsViewModels.questionsQuestionSetsViewModelSetIdLessThenOne;

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
            var model = ValidQuestionsQuestionSetsViewModels.questionsQuestionSetsViewModelValidModelQuestionIdLessThenOne;

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
            var model = ValidQuestionsQuestionSetsViewModels.questionsQuestionSetsViewModelWithoutQuestionId;

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
            var model = ValidQuestionsQuestionSetsViewModels.questionsQuestionSetsViewModelWithoutSetId;

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.QuestionSetId));
        }
    }
}
