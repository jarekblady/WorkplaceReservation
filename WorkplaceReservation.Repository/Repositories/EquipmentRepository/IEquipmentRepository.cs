using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkplaceReservation.Repository.Entities;

namespace WorkplaceReservation.Repository.Repositories.EquipmentRepository
{
    public interface IEquipmentRepository
    {
        List<Equipment> EquipmentGetAll();
        Equipment EquipmentGetById(int id);
        void CreateEquipment(Equipment equipment);
        void UpdateEquipment(Equipment equipment);
        void DeleteEquipment(Equipment equipment);
    }
}
