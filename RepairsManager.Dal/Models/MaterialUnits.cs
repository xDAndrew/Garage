using System.Collections.Generic;

namespace RepairsManager.Dal.Models
{
    public partial class MaterialUnits
    {
        public MaterialUnits()
        {
            Material = new HashSet<Material>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Material> Material { get; set; }
    }
}
