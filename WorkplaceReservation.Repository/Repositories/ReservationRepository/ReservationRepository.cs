using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkplaceReservation.Repository.Context;
using WorkplaceReservation.Repository.Entities;

namespace WorkplaceReservation.Repository.Repositories.ReservationRepository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly WorkplaceDbContext _context;

        public ReservationRepository(WorkplaceDbContext context)
        {
            _context = context;
        }

        public List<Reservation> ReservationGetAll()
        {

            return _context.Reservations.Include(e => e.Employee).Include(w => w.Workplace).ToList();
        }

        public Reservation ReservationGetById(int id)
        {
            return _context.Reservations.Include(e => e.Employee).Include(w => w.Workplace).FirstOrDefault(r => r.Id == id);
        }


        public void CreateReservation(Reservation reservation)
        {

            _context.Reservations.Add(reservation);
            _context.SaveChanges();

        }

        public void UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();

        }
        public void DeleteReservation(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);

            _context.SaveChanges();

        }
    }
}
