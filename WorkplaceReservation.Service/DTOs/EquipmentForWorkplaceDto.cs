using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkplaceReservation.Service.DTOs
{
    public class EquipmentForWorkplaceDto
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int WorkplaceId { get; set; }
        public int EquipmentId { get; set; }
        public string WorkplaceName { get; set; }
        public string Type { get; set; }
    }
}
