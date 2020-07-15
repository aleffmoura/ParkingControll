using MediatR;
using ParkingControll.Application.Features.Vehicles.Handlers.Commands;
using ParkingControll.Domain.Features.Vehicles;
using ParkingControll.Infra.CrossCutting.Structs;
using System;
using System.Linq;

namespace ParkingControll.Application.Features.Vehicles.Handlers
{
    public class VehicleCollectionHandler : RequestHandler<VehicleQueryAll, Option<Exception, IQueryable<Vehicle>>>
    {
        private IVehicleRepository _repository;
        public VehicleCollectionHandler(IVehicleRepository repository)
        {
            _repository = repository;
        }

        protected override Option<Exception, IQueryable<Vehicle>> Handle(VehicleQueryAll request)
        {
            return _repository.GetAll(request.Period);
        }
    }
}
