using System;
using System.Collections.Generic;

namespace RepairsManager.Dal.Models
{
    public partial class VehicleModel
    {
        public VehicleModel()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int MarkId { get; set; }

        public virtual VehicleMark Mark { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
