using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WorkplaceReservation.Repository.Entities;
using WorkplaceReservation.Repository.Repositories.ReservationRepository;
using WorkplaceReservation.Service.DTOs;

namespace WorkplaceReservation.Service.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }


        public List<ReservationDto> GetAllReservation()
        {
            var reservations = _reservationRepository.ReservationGetAll();
            var result = _mapper.Map<List<ReservationDto>>(reservations);
            return result;
        }

        public ReservationDto GetByIdReservation(int id)
        {
            var reservation = _reservationRepository.ReservationGetById(id);
            var result = _mapper.Map<ReservationDto>(reservation);
            return result;
        }


        public void CreateReservation(ReservationDto dto)
        {
            var reservation = _mapper.Map<Reservation>(dto);
            _reservationRepository.CreateReservation(reservation);
        }

        public void UpdateReservation(ReservationDto dto)
        {
            var reservation = _mapper.Map<Reservation>(dto);
            _reservationRepository.UpdateReservation(reservation);
        }

        public void DeleteReservation(int id)
        {
            var reservation = _reservationRepository.ReservationGetById(id);
            _reservationRepository.DeleteReservation(reservation);
        }
    }
}
