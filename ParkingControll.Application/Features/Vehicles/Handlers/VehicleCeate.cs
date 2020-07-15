using AutoMapper;
using MediatR;
using ParkingControll.Domain.Exceptions;
using ParkingControll.Domain.Features.Vehicles;
using ParkingControll.Infra.CrossCutting.Structs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingControll.Application.Features.Vehicles.Handlers
{
    public class VehicleCeate : IRequestHandler<Commands.VehicleCreateCommand, Option<Exception, Guid>>
    {
        private readonly IVehicleRepository _repository;

        public VehicleCeate(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<Exception, Guid>> Handle(Commands.VehicleCreateCommand request, CancellationToken cancellationToken)
        {
            var allReadInParking = await _repository.GetByPlateAsync(request.Plate);

            if (allReadInParking.IsSuccess)
                return new DuplicateException("Já existe um carro com a placa informada no estacionamento");

            var createCallBack = await _repository.CreateAsync(Mapper.Map<Vehicle>(request));

            if (createCallBack.IsFailure)
                return createCallBack.Failure;

            return createCallBack.Success.Id;
        }

    }
}
