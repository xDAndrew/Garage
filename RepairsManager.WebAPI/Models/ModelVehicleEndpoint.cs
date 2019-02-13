using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairsManager.WebAPI.Models
{
    public class ModelVehicleEndpoint
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public int VehicleMarkId { get; set; }
     }
}
