using System;
using System.Collections.Generic;

namespace RepairsManager.Dal.Models
{
    public partial class RepairWork
    {
        public RepairWork()
        {
            RepairPart = new HashSet<RepairPart>();
        }

        public int Id { get; set; }
        public string WorkName { get; set; }

        public virtual ICollection<RepairPart> RepairPart { get; set; }
    }
}
