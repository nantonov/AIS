using AIS.API.ViewModels.QuestionArea;
using FluentValidation;

namespace AIS.API.Validators.QuestionArea
{
    public class QuestionAreaUpdateViewModelValidator : AbstractValidator<QuestionAreaUpdateViewModel>
    {
        public QuestionAreaUpdateViewModelValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(3);
        }
    }
}
