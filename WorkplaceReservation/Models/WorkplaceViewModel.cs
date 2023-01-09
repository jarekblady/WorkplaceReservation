using WorkplaceReservation.Service.DTOs;

namespace WorkplaceReservation.Models
{
    public class WorkplaceViewModel
    {
        public List<WorkplaceDto> Workplaces { get; set; }
        public WorkplaceDto Workplace { get; set; }
    }
}
