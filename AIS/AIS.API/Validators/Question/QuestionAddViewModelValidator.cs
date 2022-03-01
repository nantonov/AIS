using AIS.API.ViewModels.Question;
using FluentValidation;

namespace AIS.API.Validators.Question
{
    public class QuestionAddViewModelValidator : AbstractValidator<QuestionAddViewModel>
    {
        public QuestionAddViewModelValidator()
        {
            RuleFor(x => x.Text).NotNull().MinimumLength(10);
        }
    }
}
