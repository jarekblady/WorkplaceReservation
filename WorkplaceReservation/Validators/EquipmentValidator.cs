using FluentValidation;
using WorkplaceReservation.Models;

namespace WorkplaceReservation.Validators
{
    public class EquipmentValidator : AbstractValidator<EquipmentViewModel>
    {
        public EquipmentValidator()
        {
            RuleFor(x => x.Equipment.Type).NotEmpty().WithMessage("Equipment type is required");
        }
    }
}
