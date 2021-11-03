using AIS.API.ViewModels.Question;
using FluentValidation;

namespace AIS.API.Validators.Question
{
    public class QuestionAddViewModelValidator : AbstractValidator<QuestionAddViewModel>
    {
        public QuestionAddViewModelValidator()
        {
            RuleFor(x => x.QuestionSetId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Text).NotNull().MinimumLength(10);
        }
    }
}
