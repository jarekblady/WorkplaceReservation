using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WorkplaceReservation.Repository.Entities;
using WorkplaceReservation.Repository.Repositories.EquipmentForWorkplaceRepository;
using WorkplaceReservation.Repository.Repositories.WorkplaceRepository;
using WorkplaceReservation.Service.DTOs;

namespace WorkplaceReservation.Service.Services.WorkplaceService
{
    public class WorkplaceService : IWorkplaceService
    {


        private readonly IWorkplaceRepository _workplaceRepository;
        private readonly IEquipmentForWorkplaceRepository _equipmentForWorkplaceRepository;
        private readonly IMapper _mapper;

        public WorkplaceService(IWorkplaceRepository workplaceRepository, IEquipmentForWorkplaceRepository equipmentForWorkplaceRepository, IMapper mapper)
        {
            _workplaceRepository = workplaceRepository;
            _equipmentForWorkplaceRepository = equipmentForWorkplaceRepository;
            _mapper = mapper;
        }


        public List<WorkplaceDto> GetAllWorkplace()
        {
            var workplaces = _workplaceRepository.WorkplaceGetAll();
            var result = _mapper.Map<List<WorkplaceDto>>(workplaces);
            return result;
        }

        public WorkplaceDto GetByIdWorkplace(int id)
        {
            var workplace = _workplaceRepository.WorkplaceGetById(id);
            var result = _mapper.Map<WorkplaceDto>(workplace);
            return result;
        }


        public void CreateWorkplace(WorkplaceDto dto)
        {
            var workplace = _mapper.Map<Workplace>(dto);
            _workplaceRepository.CreateWorkplace(workplace);
        }

        public void UpdateWorkplace(WorkplaceDto dto)
        {
            var workplace = _mapper.Map<Workplace>(dto);
            _workplaceRepository.UpdateWorkplace(workplace);
        }

        public void DeleteWorkplace(int id)
        {
            var workplace = _workplaceRepository.WorkplaceGetById(id);
            _workplaceRepository.DeleteWorkplace(workplace);
        }



        public List<EquipmentForWorkplaceDto> GetAllEquipmentForWorkplaceId(int workplaceId)
        {
            var equipmentForWorkplaces = _equipmentForWorkplaceRepository.GetAllEquipmentForWorkplaceId(workplaceId);
            var result = _mapper.Map<List<EquipmentForWorkplaceDto>>(equipmentForWorkplaces);
            return result;
        }

        public List<EquipmentForWorkplaceDto> GetAllEquipmentForWorkplace()
        {
            var equipmentForWorkplaces = _equipmentForWorkplaceRepository.EquipmentForWorkplaceGetAll();
            var result = _mapper.Map<List<EquipmentForWorkplaceDto>>(equipmentForWorkplaces);
            return result;
        }
        public EquipmentForWorkplaceDto GetByIdEquipmentForWorkplace(int id)
        {
            var equipmentForWorkplace = _equipmentForWorkplaceRepository.EquipmentForWorkplaceGetById(id);
            var result = _mapper.Map<EquipmentForWorkplaceDto>(equipmentForWorkplace);
            return result;
        }


        public void AddEquipmentForWorkplace(EquipmentForWorkplaceDto dto)
        {
            var equipmentForWorkplace = _mapper.Map<EquipmentForWorkplace>(dto);
            _equipmentForWorkplaceRepository.CreateEquipmentForWorkplace(equipmentForWorkplace);
        }

        public void UpdateEquipmentForWorkplace(EquipmentForWorkplaceDto dto)
        {
            var equipmentForWorkplace = _mapper.Map<EquipmentForWorkplace>(dto);
            _equipmentForWorkplaceRepository.UpdateEquipmentForWorkplace(equipmentForWorkplace);
        }

        public void DeleteEquipmentForWorkplace(int id)
        {
            var equipmentForWorkplace = _equipmentForWorkplaceRepository.EquipmentForWorkplaceGetById(id);
            _equipmentForWorkplaceRepository.DeleteEquipmentForWorkplace(equipmentForWorkplace);
        }

    }
}
