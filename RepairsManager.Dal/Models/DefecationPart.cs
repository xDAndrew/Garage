using System.Collections.Generic;

namespace RepairsManager.Dal.Models
{
    public partial class DefecationPart
    {
        public DefecationPart()
        {
            Defecation = new HashSet<Defecation>();
        }

        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int Amount { get; set; }
        public string Scope { get; set; }

        public virtual Material Material { get; set; }
        public virtual ICollection<Defecation> Defecation { get; set; }
    }
}
