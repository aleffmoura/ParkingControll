using AutoMapper;
using ParkingControll.Application.Features.Vehicles.Handlers.Commands;
using ParkingControll.Application.Features.Vehicles.ViewModels;
using ParkingControll.Domain.Features.Vehicles;
using System;

namespace ParkingControll.Application.Features.Vehicles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VehicleCreateCommand, Vehicle>()
                .ForMember(dest => dest.CameIn, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Exited, opt => opt.MapFrom(src => (DateTime?)null));

            CreateMap<Vehicle, VehicleViewModel>();
            CreateMap<Vehicle, VehicleAmountViewModel>();
            CreateMap<VehicleAmountViewModel, VehicleAmountViewModel>();
        }
    }
}
