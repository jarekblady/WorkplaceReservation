using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkplaceReservation.Repository.Entities
{
    public class EquipmentForWorkplace
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public int WorkplaceId { get; set; }
        public Workplace Workplace { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}
