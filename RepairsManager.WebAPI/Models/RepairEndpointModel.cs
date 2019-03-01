using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairsManager.WebAPI.Models
{
    public class RepairEndpointModel
    {
        public int Id { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleNumber { get; set; }
        public DateTime RepairDate { get; set; }
        public string Employee { get; set; }
    }
}
