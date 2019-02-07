﻿using System.Collections.Generic;
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
                .ForMember(dist => dist.MarkName, opt => opt.MapFrom(src => src.VehicleModel.VehicleMark.Name))
                .ForMember(dist => dist.ModelName, opt => opt.MapFrom(src => src.VehicleModel.Name))
                .ForMember(dist => dist.RegNumber, opt => opt.MapFrom(src => src.RegNumber))
                .ForAllOtherMembers(opt => opt.Ignore());
            
            CreateMap<VehicleEndpointModel, Vehicle>()
                .ForMember(dist => dist.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dist => dist.RegNumber, opt => opt.MapFrom(src => src.RegNumber))
                .ForMember(dist => dist.VehicleModelId, opt => opt.MapFrom(src => src.ModelId))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}