using WorkplaceReservation.Service.DTOs;

namespace WorkplaceReservation.Models
{
    public class EquipmentForWorkplaceViewModel
    {
        public List<EquipmentForWorkplaceDto> EquipmentForWorkplaces { get; set; }
        public EquipmentForWorkplaceDto EquipmentForWorkplace { get; set; }
    }
}
