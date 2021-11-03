using AIS.API.ViewModels.QuestionArea;
using FluentValidation;

namespace AIS.API.Validators.QuestionArea
{
    public class QuestionAreaAddViewModelValidator : AbstractValidator<QuestionAreaAddViewModel>
    {
        public QuestionAreaAddViewModelValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(3);
        }
    }
}
