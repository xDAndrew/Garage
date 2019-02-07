using System.Collections.Generic;

namespace RepairsManager.Dal.Models
{
    public partial class Material
    {
        public Material()
        {
            RepairPart = new HashSet<RepairPart>();
        }

        public int Id { get; set; }
        public int PartyId { get; set; }
        public string Name { get; set; }
        public int UnitId { get; set; }
        public decimal Price { get; set; }

        public virtual MaterialParty Party { get; set; }
        public virtual MaterialUnits Unit { get; set; }
        public virtual ICollection<RepairPart> RepairPart { get; set; }
    }
}
