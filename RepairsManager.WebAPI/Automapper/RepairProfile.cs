using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RepairsManager.Dal.Models;
using RepairsManager.WebAPI.Models;

namespace RepairsManager.WebAPI.Automapper
{
    public class RepairProfile : Profile
    {
        public RepairProfile()
        {
            CreateMap<Repair, RepairEndpointModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dist => dist.VehicleModel, opt => opt.MapFrom(src => $"{src.Vehicle.Model.Mark.Name} {src.Vehicle.Model.Name}"))
                .ForMember(dist => dist.VehicleNumber, opt => opt.MapFrom(src => src.Vehicle.RegNumber))
                .ForMember(dist => dist.RepairDate, opt => opt.MapFrom(src => src.RepairDate.ToString("dd.MM.yyyy")))
                .ForMember(dist => dist.Employee, opt => new string("Пупкин В.В."))
                .ForAllOtherMembers(opt => opt.Ignore());

            /*
            CreateMap<VehicleEndpointModel, Vehicle>()
                .ForMember(dist => dist.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dist => dist.ModelId, opt => opt.MapFrom(src => src.ModelId))
                .ForMember(dist => dist.RegNumber, opt => opt.MapFrom(src => src.RegNumber))
                .ForAllOtherMembers(opt => opt.Ignore());
            */
        }
    }
}
