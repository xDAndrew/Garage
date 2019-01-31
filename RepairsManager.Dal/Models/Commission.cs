using System;
using System.Collections.Generic;

namespace RepairsManager.Dal.Models
{
    public partial class Commission
    {
        public Commission()
        {
            CommissionResponsible = new HashSet<CommissionResponsible>();
            Depreciation = new HashSet<Depreciation>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ChairmanId { get; set; }

        public virtual ICollection<CommissionResponsible> CommissionResponsible { get; set; }
        public virtual ICollection<Depreciation> Depreciation { get; set; }
    }
}
