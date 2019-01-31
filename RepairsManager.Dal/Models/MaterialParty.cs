using System;
using System.Collections.Generic;

namespace RepairsManager.Dal.Models
{
    public partial class MaterialParty
    {
        public MaterialParty()
        {
            Material = new HashSet<Material>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime? Receipt { get; set; }

        public virtual ICollection<Material> Material { get; set; }
    }
}
