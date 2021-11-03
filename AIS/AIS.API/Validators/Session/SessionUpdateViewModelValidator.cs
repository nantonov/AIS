using AIS.API.ViewModels.Session;
using FluentValidation;

namespace AIS.API.Validators.Session
{
    public class SessionUpdateViewModelValidator : AbstractValidator<SessionUpdateViewModel>
    {
        public SessionUpdateViewModelValidator()
        {
            RuleFor(x => x.QuestionAreaId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.IntervieweeId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.EmployeeId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.CompanyId).NotEmpty().GreaterThan(0);
        }
    }
}
