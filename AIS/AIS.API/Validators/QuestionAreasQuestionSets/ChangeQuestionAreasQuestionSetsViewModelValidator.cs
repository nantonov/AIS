using AIS.API.ViewModels.QuestionAreasQuestionSets;
using FluentValidation;

namespace AIS.API.Validators.QuestionAreasQuestionSets
{
    public class ChangeQuestionAreasQuestionSetsViewModelValidator : AbstractValidator<ChangeQuestionAreasQuestionSetsViewModel>
    {
        public ChangeQuestionAreasQuestionSetsViewModelValidator()
        {
            RuleFor(x => x.QuestionSetId).NotNull().GreaterThan(0);
            RuleFor(x => x.QuestionAreaId).NotNull().GreaterThan(0);
        }
    }
}
