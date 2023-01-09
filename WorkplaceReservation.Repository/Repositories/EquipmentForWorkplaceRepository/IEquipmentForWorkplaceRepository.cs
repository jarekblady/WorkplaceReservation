using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkplaceReservation.Repository.Entities;

namespace WorkplaceReservation.Repository.Repositories.EquipmentForWorkplaceRepository
{
    public interface IEquipmentForWorkplaceRepository
    {
        List<EquipmentForWorkplace> EquipmentForWorkplaceGetAll();
        List<EquipmentForWorkplace> GetAllEquipmentForWorkplaceId(int workplaceId);
        EquipmentForWorkplace EquipmentForWorkplaceGetById(int id);
        void CreateEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace);
        void UpdateEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace);
        void DeleteEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace);
    }
}
