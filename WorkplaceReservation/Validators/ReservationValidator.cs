using FluentValidation;
using WorkplaceReservation.Models;

namespace WorkplaceReservation.Validators
{
    public class ReservationValidator : AbstractValidator<ReservationViewModel>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.Reservation.EmployeeId)
                .NotEmpty().WithMessage("Employee is required");

            RuleFor(x => x.Reservation.WorkplaceId)
                .NotEmpty().WithMessage("Workplace is required");

            RuleFor(x => x.Reservation.TimeFrom)
                .NotNull().WithMessage("TimeFrom is required");

            RuleFor(x => x.Reservation.TimeTo)
                .NotNull().WithMessage("TimeTo is required")
                .GreaterThan(x => x.Reservation.TimeFrom).WithMessage("TimeTo must be after this TimeFrom");
        }
    }
}
