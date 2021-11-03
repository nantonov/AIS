using AIS.API.ViewModels.TrueAnswer;
using FluentValidation;

namespace AIS.API.Validators.TrueAnswer
{
    public class TrueAnswerUpdateViewModelValidator : AbstractValidator<TrueAnswerUpdateViewModel>
    {
        public TrueAnswerUpdateViewModelValidator()
        {
            RuleFor(x => x.Text).NotNull().MinimumLength(10);
            RuleFor(x => x.QuestionId).NotEmpty().GreaterThan(0);
        }
    }
}
