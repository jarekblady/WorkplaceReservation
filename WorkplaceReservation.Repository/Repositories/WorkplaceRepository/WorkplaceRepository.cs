using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkplaceReservation.Repository.Context;
using WorkplaceReservation.Repository.Entities;

namespace WorkplaceReservation.Repository.Repositories.WorkplaceRepository
{
    public class WorkplaceRepository : IWorkplaceRepository
    {
        private readonly WorkplaceDbContext _context;

        public WorkplaceRepository(WorkplaceDbContext context)
        {
            _context = context;
        }



        public List<Workplace> WorkplaceGetAll()
        {

            return _context.Workplaces.Include(e => e.EquipmentForWorkplaces).ToList();
        }

        public Workplace WorkplaceGetById(int id)
        {
            return _context.Workplaces.Include(e => e.EquipmentForWorkplaces).FirstOrDefault(w => w.Id == id);
        }

        public void CreateWorkplace(Workplace workplace)
        {

            _context.Workplaces.Add(workplace);
            _context.SaveChanges();

        }

        public void UpdateWorkplace(Workplace workplace)
        {
            _context.Workplaces.Update(workplace);
            _context.SaveChanges();

        }
        public void DeleteWorkplace(Workplace workplace)
        {
            _context.Workplaces.Remove(workplace);

            _context.SaveChanges();

        }
    }
}
