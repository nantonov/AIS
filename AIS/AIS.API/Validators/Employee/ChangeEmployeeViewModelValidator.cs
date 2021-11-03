using AIS.API.ViewModels.Employee;
using FluentValidation;

namespace AIS.API.Validators.Employee
{
    public class ChangeEmployeeViewModelValidator : AbstractValidator<ChangeEmployeeViewModel>
    {
        public ChangeEmployeeViewModelValidator()
        {
            RuleFor(x => x.CompanyId).NotNull().GreaterThan(0);
            RuleFor(x => x.Name).NotNull().MinimumLength(3);
        }
    }
}
