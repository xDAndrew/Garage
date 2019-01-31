using System;
using System.Collections.Generic;

namespace RepairsManager.Dal.Models
{
    public partial class Defecation
    {
        public Defecation()
        {
            DefecationResponsible = new HashSet<DefecationResponsible>();
        }

        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int PartId { get; set; }
        public DateTime CreateOn { get; set; }
        public int ApprovedId { get; set; }

        public virtual Employee Approved { get; set; }
        public virtual DefecationPart Part { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<DefecationResponsible> DefecationResponsible { get; set; }
    }
}
