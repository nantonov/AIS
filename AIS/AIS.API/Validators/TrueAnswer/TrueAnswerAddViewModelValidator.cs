using AIS.API.ViewModels.TrueAnswer;
using FluentValidation;

namespace AIS.API.Validators.TrueAnswer
{
    public class TrueAnswerAddViewModelValidator : AbstractValidator<TrueAnswerAddViewModel>
    {
        public TrueAnswerAddViewModelValidator()
        {
            RuleFor(x => x.QuestionId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Text).NotNull().MinimumLength(10);
        }
    }
}
