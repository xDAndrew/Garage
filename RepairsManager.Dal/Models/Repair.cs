using System;
using System.Collections.Generic;

namespace RepairsManager.Dal.Models
{
    public partial class Repair
    {
        public Repair()
        {
            RepairPart = new HashSet<RepairPart>();
        }

        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateTime RepairDate { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<RepairPart> RepairPart { get; set; }
    }
}
