using AutoMapper;
using RepairsManager.Dal.Models;
using RepairsManager.WebAPI.Models;

namespace RepairsManager.WebAPI.Automapper
{
    public class ModelVehicle : Profile
    {
       public ModelVehicle()
        {
            CreateMap<VehicleModel, ModelVehicleEndpoint>()
                .ForMember(dest => dest.Id, m => m.MapFrom(srv => srv.Id))
                .ForMember(dest => dest.VehicleMarkId, m => m.MapFrom(srv => srv.MarkId))
                .ForMember(dest => dest.Name, m => m.MapFrom(srv => srv.Name))
                .ForAllOtherMembers(m => m.Ignore());
        }
    }
}
