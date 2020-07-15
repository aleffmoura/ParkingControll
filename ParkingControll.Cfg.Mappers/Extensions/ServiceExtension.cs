using Microsoft.Extensions.DependencyInjection;
using System;

namespace ParkingControll.Cfg.Mappers.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services, params Type[] types)
        {
            AutoMapper.Mapper.Reset();
            AutoMapper.Mapper.Initialize(cfg =>
            {
                foreach (Type type in types)
                {
                    cfg.AddProfiles(type);
                }
            });
        }

    }
}
