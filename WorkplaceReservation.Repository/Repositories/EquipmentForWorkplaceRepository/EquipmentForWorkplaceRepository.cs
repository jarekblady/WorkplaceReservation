using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkplaceReservation.Repository.Context;
using WorkplaceReservation.Repository.Entities;

namespace WorkplaceReservation.Repository.Repositories.EquipmentForWorkplaceRepository
{
    public class EquipmentForWorkplaceRepository : IEquipmentForWorkplaceRepository
    {
        private readonly WorkplaceDbContext _context;

        public EquipmentForWorkplaceRepository(WorkplaceDbContext context)
        {
            _context = context;
        }

        public List<EquipmentForWorkplace> EquipmentForWorkplaceGetAll()
        {

            return _context.EquipmentForWorkplaces.Include(e => e.Equipment).Include(w => w.Workplace).ToList();
        }
        public List<EquipmentForWorkplace> GetAllEquipmentForWorkplaceId(int workplaceId)
        {
            return _context.EquipmentForWorkplaces.Include(e => e.Equipment).Include(w => w.Workplace).Where(e => e.WorkplaceId == workplaceId).ToList();
        }

        public EquipmentForWorkplace EquipmentForWorkplaceGetById(int id)
        {
            return _context.EquipmentForWorkplaces.Include(e => e.Equipment).Include(w => w.Workplace).FirstOrDefault(r => r.Id == id);
        }

        public void CreateEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace)
        {

            _context.EquipmentForWorkplaces.Add(equipmentForWorkplace);
            _context.SaveChanges();

        }

        public void UpdateEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace)
        {
            _context.EquipmentForWorkplaces.Update(equipmentForWorkplace);
            _context.SaveChanges();

        }
        public void DeleteEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace)
        {
            _context.EquipmentForWorkplaces.Remove(equipmentForWorkplace);

            _context.SaveChanges();

        }
    }
}