using FluentValidation;
using WorkplaceReservation.Models;

namespace WorkplaceReservation.Validators
{
    public class WorkplaceValidator : AbstractValidator<WorkplaceViewModel>
    {
        public WorkplaceValidator()
        {
            RuleFor(x => x.Workplace.Floor)
                .NotNull().WithMessage("Floor is required");

            RuleFor(x => x.Workplace.Room)
                .NotNull().WithMessage("Room is required");

            RuleFor(x => x.Workplace.Table)
                .NotNull().WithMessage("Table is required");
        }
    }
}