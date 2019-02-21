using System;
using System.Collections.Generic;

namespace RepairsManager.Dal.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Repair = new HashSet<Repair>();
        }

        public int Id { get; set; }
        public int ModelId { get; set; }
        public string RegNumber { get; set; }

        public virtual VehicleModel Model { get; set; }
        public virtual ICollection<Repair> Repair { get; set; }
    }
}
