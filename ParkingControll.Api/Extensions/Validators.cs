using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using System.Reflection;

namespace ParkingControll.Api.Extensions
{
    public static class Validators
    {
        public static void AddValidators(this IServiceCollection services, Container container)
        {
            container.Collection.Register(typeof(IValidator<>), typeof(Application.Module).GetTypeInfo().Assembly);
        }
    }
}
