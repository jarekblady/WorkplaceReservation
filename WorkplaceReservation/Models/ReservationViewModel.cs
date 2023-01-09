using WorkplaceReservation.Service.DTOs;

namespace WorkplaceReservation.Models
{
    public class ReservationViewModel
    {
        public List<ReservationDto> Reservations { get; set; }
        public ReservationDto Reservation { get; set; }

    }
}
