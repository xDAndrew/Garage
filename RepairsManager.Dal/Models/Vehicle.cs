using System.Collections.Generic;

namespace RepairsManager.Dal.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Defecation = new HashSet<Defecation>();
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int VehicleModelId { get; set; }
        public string RegNumber { get; set; }
        public int DriverId { get; set; }

        public virtual Employee Driver { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
        public virtual ICollection<Defecation> Defecation { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
