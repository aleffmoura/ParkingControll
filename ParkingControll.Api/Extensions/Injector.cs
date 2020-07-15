using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ParkingControll.Application.Features.PriceAggregation.Services;
using ParkingControll.Domain.Features.PriceAggregation;
using ParkingControll.Domain.Features.Vehicles;
using ParkingControll.Infra.CrossCutting.Constants;
using ParkingControll.Infra.Data.Contexts;
using ParkingControll.Infra.Data.Features.Prices;
using ParkingControll.Infra.Data.Features.Vehicles;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using System.Net.Http;

namespace ParkingControll.Api.Extensions
{
    public static class Injector
    {
        public static void AddSimpleInjector(this IServiceCollection services, Container container)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));
            services.UseSimpleInjectorAspNetRequestScoping(container);
            services.EnableSimpleInjectorCrossWiring(container);
        }

        public static void AddDependencies(this IServiceCollection services,
            Container container)
        {
            container.Register(() =>
            {
                var options = new DbContextOptionsBuilder<ParkingContext>().UseSqlServer(Consts.ConnectionString).Options;
                return new ParkingContext(options);
            }, Lifestyle.Scoped);


            RegisterFeatures(container);

            services.AddScoped(s => s.GetRequiredService<IHttpClientFactory>().CreateClient());

        }

        private static void RegisterFeatures(Container container)
        {
            container.Register<IPriceRepository, PriceRepository>();
            container.Register<IVehicleRepository, VehicleRepository>();
            container.Register(() => new PriceLogicService());
        }
    }
}
