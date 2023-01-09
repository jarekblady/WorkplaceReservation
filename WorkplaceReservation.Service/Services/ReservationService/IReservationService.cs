using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkplaceReservation.Service.DTOs;

namespace WorkplaceReservation.Service.Services.ReservationService
{
    public interface IReservationService
    {
        List<ReservationDto> GetAllReservation();
        ReservationDto GetByIdReservation(int id);
        void CreateReservation(ReservationDto dto);
        void UpdateReservation(ReservationDto dto);
        void DeleteReservation(int id);
    }
}
