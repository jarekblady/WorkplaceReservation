using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkplaceReservation.Repository.Entities
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<EquipmentForWorkplace> EquipmentForWorkplaces { get; set; }
    }
}
