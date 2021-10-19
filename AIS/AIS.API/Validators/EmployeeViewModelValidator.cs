using AIS.API.ViewModels.Employee;
using FluentValidation;

namespace AIS.API.Validators
{
    public class EmployeeViewModelValidator : AbstractValidator<EmployeeViewModel>
    {
        public EmployeeViewModelValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(3);
            RuleFor(x => x.CompanyId).NotNull().GreaterThan(0);
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
        }
    }
}
