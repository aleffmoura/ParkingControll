using MediatR;
using ParkingControll.Domain.Features.Vehicles;
using ParkingControll.Infra.CrossCutting.Structs;
using System;
using System.Linq;

namespace ParkingControll.Application.Features.Vehicles.Handlers.Commands
{
    public class VehicleQueryAll : IRequest<Option<Exception, IQueryable<Vehicle>>>
    {
        public DateTime Period { get; set; }

        public VehicleQueryAll(DateTime period)
        {
            Period = period;
        }
    }
}
