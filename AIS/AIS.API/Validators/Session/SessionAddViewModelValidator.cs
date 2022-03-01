using AIS.API.ViewModels.Session;
using FluentValidation;

namespace AIS.API.Validators.Session
{
    public class SessionAddViewModelValidator : AbstractValidator<SessionAddViewModel>
    {
        public SessionAddViewModelValidator()
        {
            RuleFor(x => x.EmployeeId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.IntervieweeId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.QuestionAreaId).NotEmpty().GreaterThan(0);
        }
    }
}
