using AIS.API.ViewModels.QuestionIntervieweeAnswer;
using FluentValidation;

namespace AIS.API.Validators.QuestionIntervieweeAnswer
{
    public class QuestionIntervieweeAnswerAddViewModelValidator : AbstractValidator<QuestionIntervieweeAnswerAddViewModel>
    {
        public QuestionIntervieweeAnswerAddViewModelValidator()
        {
            RuleFor(x => x.Mark).NotEmpty().GreaterThan(-1).LessThan(11);
            RuleFor(x => x.QuestionId).NotEmpty().GreaterThan(0);
        }
    }
}
