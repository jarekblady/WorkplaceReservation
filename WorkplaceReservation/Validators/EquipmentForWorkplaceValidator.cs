using FluentValidation;
using WorkplaceReservation.Models;

namespace WorkplaceReservation.Validators
{
    public class EquipmentForWorkplaceValidator : AbstractValidator<EquipmentForWorkplaceViewModel>
    {
        public EquipmentForWorkplaceValidator()
        {
            RuleFor(x => x.EquipmentForWorkplace.WorkplaceId)
                .NotEmpty().WithMessage("Workplace is required");

            RuleFor(x => x.EquipmentForWorkplace.EquipmentId)
                .NotEmpty().WithMessage("Equipment is required");

            RuleFor(x => x.EquipmentForWorkplace.Count)
                .NotNull().WithMessage("Count is required");
        }
    }
}
