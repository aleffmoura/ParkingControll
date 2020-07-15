using MediatR;
using ParkingControll.Application.Features.PriceAggregation.Services;
using ParkingControll.Application.Features.Vehicles.Handlers.Commands;
using ParkingControll.Domain.Exceptions;
using ParkingControll.Domain.Features.PriceAggregation;
using ParkingControll.Domain.Features.Vehicles;
using ParkingControll.Infra.CrossCutting.Structs;
using System;
using System.Threading;
using System.Threading.Tasks;
using Unit = ParkingControll.Infra.CrossCutting.Structs.Unit;

namespace ParkingControll.Application.Features.Vehicles.Handlers
{
    public class VehicleExitedUpdate : IRequestHandler<VehicleUpdateCommand, Option<Exception, Unit>>
    {
        private readonly IVehicleRepository _repository;
        private readonly IPriceRepository _priceRepository;
        private readonly PriceLogicService _priceLogicService;

        public VehicleExitedUpdate(IVehicleRepository repository, IPriceRepository priceRepository, PriceLogicService priceLogicService)
        {
            _repository = repository;
            _priceRepository = priceRepository;
            _priceLogicService = priceLogicService;
        }

        public async Task<Option<Exception, Unit>> Handle(VehicleUpdateCommand request, CancellationToken cancellationToken)
        {
            Option<Exception, Vehicle> callback = await _repository.GetByPlateAsync(request.Plate);

            if (callback.IsFailure)
                return callback.Failure;

            var priceCallback = await _priceRepository.GetByDateAsync(callback.Success.CameIn);

            if (priceCallback.IsFailure)
                return new NotAllowedException("Operação não permitida devido a não havar um preço para o periodo ao qual o carro entou no estacionamento.");

            var timeInParking = DateTime.Now - callback.Success.CameIn;

            var logic = _priceLogicService.AmountPaid(timeInParking, priceCallback.Success);

            if (logic.IsFailure)
                return logic.Failure;

            callback.Success.Price = priceCallback.Success.Value;
            callback.Success.Exited = DateTime.Now;
            callback.Success.AmountPaid = $"R$ {logic.Success.Item1}";
            callback.Success.TotalTimePaid = $"{logic.Success.Item2} {(timeInParking.TotalMinutes <= 30 ? "min" : "hrs")}";
            callback.Success.TotalTimeInParking = $"{logic.Success.Item3} hrs";

            return await _repository.UpdateAsync(callback.Success);
        }

    }
}
