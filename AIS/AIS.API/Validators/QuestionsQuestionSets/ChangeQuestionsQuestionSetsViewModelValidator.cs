using AIS.API.ViewModels.QuestionsQuestionSets;
using FluentValidation;

namespace AIS.API.Validators.QuestionsQuestionSets
{
    public class ChangeQuestionsQuestionSetsViewModelValidator : AbstractValidator<ChangeQuestionsQuestionSetsViewModel>
    {
        public ChangeQuestionsQuestionSetsViewModelValidator()
        {
            RuleFor(x => x.QuestionSetId).NotNull().GreaterThan(0);
            RuleFor(x => x.QuestionId).NotNull().GreaterThan(0);
        }
    }
}
