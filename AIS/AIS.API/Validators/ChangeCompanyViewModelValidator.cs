using AIS.API.ViewModels.Company;
using FluentValidation;

namespace AIS.API.Validators
{
    public class ChangeCompanyViewModelValidator : AbstractValidator<ChangeCompanyViewModel>
    {
        public ChangeCompanyViewModelValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(3);
        }
    }
}
