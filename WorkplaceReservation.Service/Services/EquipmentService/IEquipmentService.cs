using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkplaceReservation.Service.DTOs;

namespace WorkplaceReservation.Service.Services.EquipmentService
{
    public interface IEquipmentService
    {
        List<EquipmentDto> GetAllEquipment();
        EquipmentDto GetByIdEquipment(int id);
        void CreateEquipment(EquipmentDto dto);
        void UpdateEquipment(EquipmentDto dto);
        void DeleteEquipment(int id);
    }
}