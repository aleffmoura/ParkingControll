using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ParkingControll.Api.Behavious;
using ParkingControll.Api.Extensions;
using ParkingControll.Cfg.Mappers.Extensions;
using SimpleInjector;

namespace ParkingControll.Api
{
    public class Startup
    {
        private readonly Container container = new Container();

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSimpleInjector(container);
            services.AddOData();
            services.AddAutoMapper(typeof(Application.Module));
            services.AddDependencies(container);
            services.AddMediator(container);
            services.AddValidators(container);
            services.AddMvcCore(options => options.Filters.Add(new ExceptionHandlerAttribute())).AddJsonFormatters();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseOData();
            container.RegisterMvcControllers(app);
            app.UseMvc();
        }
    }
}
