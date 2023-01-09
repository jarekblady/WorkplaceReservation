using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkplaceReservation.Repository.Context;
using WorkplaceReservation.Repository.Entities;

namespace WorkplaceReservation.Repository.Repositories.EquipmentRepository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly WorkplaceDbContext _context;

        public EquipmentRepository(WorkplaceDbContext context)
        {
            _context = context;
        }



        public List<Equipment> EquipmentGetAll()
        {

            return _context.Equipments.ToList();
        }

        public Equipment EquipmentGetById(int id)
        {
            return _context.Equipments.FirstOrDefault(e => e.Id == id);
        }

        public void CreateEquipment(Equipment equipment)
        {

            _context.Equipments.Add(equipment);
            _context.SaveChanges();

        }

        public void UpdateEquipment(Equipment equipment)
        {
            _context.Equipments.Update(equipment);
            _context.SaveChanges();

        }
        public void DeleteEquipment(Equipment equipment)
        {
            _context.Equipments.Remove(equipment);

            _context.SaveChanges();

        }
    }
}