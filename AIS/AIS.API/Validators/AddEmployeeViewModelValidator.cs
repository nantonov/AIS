using AIS.API.ViewModels.Employee;
using FluentValidation;

namespace AIS.API.Validators
{
    public class AddEmployeeViewModelValidator : AbstractValidator<AddEmployeeViewModel>
    {
        public AddEmployeeViewModelValidator()
        {
            RuleFor(x => x.CompanyId).NotNull().GreaterThan(0);
            RuleFor(x => x.Name).NotNull().MinimumLength(3);
        }
    }
}
