using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkplaceReservation.Repository.Entities;

namespace WorkplaceReservation.Repository.Repositories.ReservationRepository
{
    public interface IReservationRepository
    {
        List<Reservation> ReservationGetAll();
        Reservation ReservationGetById(int id);
        void CreateReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(Reservation reservation);
    }
}