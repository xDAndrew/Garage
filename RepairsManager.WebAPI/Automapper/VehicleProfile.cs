using AutoMapper;
using RepairsManager.Dal.Models;
using RepairsManager.WebAPI.Models;

namespace RepairsManager.WebAPI.Automapper
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleEndpointModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dist => dist.MarkName, opt => opt.MapFrom(src => src.Model.Mark.Name))
                .ForMember(dist => dist.ModelName, opt => opt.MapFrom(src => src.Model.Name))
                .ForMember(dist => dist.RegNumber, opt => opt.MapFrom(src => src.RegNumber))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<VehicleEndpointModel, Vehicle>()
                .ForMember(dist => dist.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dist => dist.ModelId, opt => opt.MapFrom(src => src.ModelId))
                .ForMember(dist => dist.RegNumber, opt => opt.MapFrom(src => src.RegNumber))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
