using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WorkplaceReservation.Repository.Entities;
using WorkplaceReservation.Repository.Repositories.EquipmentRepository;
using WorkplaceReservation.Service.DTOs;

namespace WorkplaceReservation.Service.Services.EquipmentService
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMapper _mapper;

        public EquipmentService(IEquipmentRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }


        public List<EquipmentDto> GetAllEquipment()
        {
            var equipments = _equipmentRepository.EquipmentGetAll();
            var result = _mapper.Map<List<EquipmentDto>>(equipments);
            return result;
        }

        public EquipmentDto GetByIdEquipment(int id)
        {
            var equipment = _equipmentRepository.EquipmentGetById(id);
            var result = _mapper.Map<EquipmentDto>(equipment);
            return result;
        }


        public void CreateEquipment(EquipmentDto dto)
        {
            var equipment = _mapper.Map<Equipment>(dto);
            _equipmentRepository.CreateEquipment(equipment);
        }

        public void UpdateEquipment(EquipmentDto dto)
        {
            var equipment = _mapper.Map<Equipment>(dto);
            _equipmentRepository.UpdateEquipment(equipment); ;
        }

        public void DeleteEquipment(int id)
        {
            var equipment = _equipmentRepository.EquipmentGetById(id);
            _equipmentRepository.DeleteEquipment(equipment);
        }
    }
}
