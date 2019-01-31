using System;

namespace RepairsManager.Dal.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int Speedometer { get; set; }
        public DateTime CreateOn { get; set; }
        public int StatusId { get; set; }
        public int FaultId { get; set; }

        public virtual OrderFault Fault { get; set; }
        public virtual OrderStatus Status { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
