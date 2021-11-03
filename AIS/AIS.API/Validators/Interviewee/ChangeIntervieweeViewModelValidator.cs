using AIS.API.ViewModels.Interviewee;
using FluentValidation;

namespace AIS.API.Validators.Interviewee
{
    public class ChangeIntervieweeViewModelValidator : AbstractValidator<ChangeIntervieweeViewModel>
    {
        public ChangeIntervieweeViewModelValidator()
        {
            RuleFor(x => x.CompanyId).NotNull().GreaterThan(0);
            RuleFor(x => x.AppliesFor).NotNull().MinimumLength(3);
            RuleFor(x => x.Name).NotNull().MinimumLength(3);
        }
    }
}
