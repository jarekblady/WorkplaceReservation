using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkplaceReservation.Repository.Entities;

namespace WorkplaceReservation.Repository.Repositories.WorkplaceRepository
{
    public interface IWorkplaceRepository
    {
        List<Workplace> WorkplaceGetAll();
        Workplace WorkplaceGetById(int id);
        void CreateWorkplace(Workplace workplace);
        void UpdateWorkplace(Workplace workplace);
        void DeleteWorkplace(Workplace workplace);
    }
}
