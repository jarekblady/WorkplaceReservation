using FluentValidation;
using WorkplaceReservation.Models;

namespace WorkplaceReservation.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeViewModel>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Employee.FirstName)
                .NotEmpty().WithMessage("First Name is required");

            RuleFor(x => x.Employee.LastName)
                .NotEmpty().WithMessage("Last Name is required");
        }
    }
}
