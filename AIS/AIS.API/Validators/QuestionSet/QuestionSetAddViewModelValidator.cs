using AIS.API.ViewModels.QuestionSet;
using FluentValidation;

namespace AIS.API.Validators.QuestionSet
{
    public class QuestionSetAddViewModelValidator : AbstractValidator<QuestionSetAddViewModel>
    {
        public QuestionSetAddViewModelValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(2);
        }
    }
}
