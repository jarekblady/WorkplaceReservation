using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkplaceReservation.Repository.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int WorkplaceId { get; set; }
        public Workplace Workplace { get; set; }

    }
}
