using AutoMapper;
using ParkingControll.Application.Features.PriceAggregation.Handlers.Commands;
using ParkingControll.Application.Features.PriceAggregation.ViewModels;
using ParkingControll.Domain.Features.PriceAggregation;

namespace ParkingControll.Application.Features.PriceAggregation
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<PriceCreateCommand, Price>()
                .ForMember(dest => dest.Final, opt => opt.MapFrom(src => src.Final))
                .ForMember(dest => dest.Initial, opt => opt.MapFrom(src => src.Initial));

            CreateMap<Price, PriceViewModel>();
        }
    }
}
