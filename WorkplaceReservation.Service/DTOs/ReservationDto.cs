using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkplaceReservation.Service.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public int EmployeeId { get; set; }
        public int WorkplaceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public int Table { get; set; }
        public string WorkplaceName { get; set; }
    }
}
