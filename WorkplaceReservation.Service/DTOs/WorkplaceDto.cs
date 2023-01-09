using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkplaceReservation.Service.DTOs
{
    public class WorkplaceDto
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public int Table { get; set; }
        public string WorkplaceName { get; set; }
    }
}
