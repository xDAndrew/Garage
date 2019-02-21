using System;
using System.Collections.Generic;

namespace RepairsManager.Dal.Models
{
    public partial class VehicleMark
    {
        public VehicleMark()
        {
            VehicleModel = new HashSet<VehicleModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VehicleModel> VehicleModel { get; set; }
    }
}
