using AutoMapper;
using RepairsManager.Dal.Models;
using RepairsManager.WebAPI.Models;

namespace RepairsManager.WebAPI.Automapper
{
    public class MarkVehicle : Profile
    {
        public MarkVehicle()
        {
            CreateMap<MarkEndpointModel, VehicleMark>();
        }
    }
}
