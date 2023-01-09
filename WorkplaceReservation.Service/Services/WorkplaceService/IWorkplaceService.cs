using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkplaceReservation.Service.DTOs;

namespace WorkplaceReservation.Service.Services.WorkplaceService
{
    public interface IWorkplaceService
    {
        List<WorkplaceDto> GetAllWorkplace();
        WorkplaceDto GetByIdWorkplace(int id);
        void CreateWorkplace(WorkplaceDto dto);
        void UpdateWorkplace(WorkplaceDto dto);
        void DeleteWorkplace(int id);
        List<EquipmentForWorkplaceDto> GetAllEquipmentForWorkplaceId(int workplaceId);
        List<EquipmentForWorkplaceDto> GetAllEquipmentForWorkplace();
        EquipmentForWorkplaceDto GetByIdEquipmentForWorkplace(int id);
        void AddEquipmentForWorkplace(EquipmentForWorkplaceDto dto);
        void UpdateEquipmentForWorkplace(EquipmentForWorkplaceDto dto);
        void DeleteEquipmentForWorkplace(int id);
    }
}
