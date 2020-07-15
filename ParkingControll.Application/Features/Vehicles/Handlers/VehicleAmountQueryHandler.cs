using MediatR;
using ParkingControll.Application.Features.PriceAggregation.Services;
using ParkingControll.Application.Features.Vehicles.Handlers.Commands;
using ParkingControll.Application.Features.Vehicles.ViewModels;
using ParkingControll.Domain.Exceptions;
using ParkingControll.Domain.Features.PriceAggregation;
using ParkingControll.Domain.Features.Vehicles;
using ParkingControll.Infra.CrossCutting.Structs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingControll.Application.Features.Vehicles.Handlers
{
    public class VehicleAmountQueryHandler : RequestHandler<VehicleAmountQuery, Option<Exception, IQueryable<VehicleAmountViewModel>>>
    {
        private readonly IPriceRepository _priceRepository;
        private readonly IVehicleRepository _repository;
        private readonly PriceLogicService _priceLogicService;

        public VehicleAmountQueryHandler(IVehicleRepository repository, IPriceRepository priceRepository, PriceLogicService priceLogicService)
        {
            _repository = repository;
            _priceRepository = priceRepository;
            _priceLogicService = priceLogicService;
        }

        protected override Option<Exception, IQueryable<VehicleAmountViewModel>> Handle(VehicleAmountQuery request)
        {
            var callback = _repository.GetAll();

            if (callback.IsFailure)
                return new NotFoundException("Não foi encontrado nenhum usuário com o id informado.");

            List<VehicleAmountViewModel> list = new List<VehicleAmountViewModel>();

            foreach (var item in callback.Success.Where(c => c.CameIn.Date == DateTime.Now.Date || !c.Exited.HasValue).ToList())
            {
                var priceCallback = _priceRepository.GetByDateAsync(item.CameIn).GetAwaiter().GetResult();

                if (priceCallback.IsFailure)
                    return new NotAllowedException("Operação não permitida devido a não havar um preço para o periodo ao qual o carro entou no estacionamento.");

                var timeInParking = DateTime.Now - item.CameIn;

                var logic = _priceLogicService.AmountPaid(timeInParking, priceCallback.Success);

                if (logic.IsFailure)
                    return logic.Failure;

                list.Add(new VehicleAmountViewModel
                {
                    Id = item.Id,
                    Price = priceCallback.Success.Value,
                    AmountPaid = item.AmountPaid ?? $"R$ {logic.Success.Item1}",
                    TotalTimePaid = item.TotalTimePaid ?? $"{logic.Success.Item2} {(timeInParking.TotalMinutes <= 30 ? "min" : "hrs")}",
                    TotalTimeInParking = item.TotalTimeInParking ?? $"{logic.Success.Item3} hrs",
                    Plate = item.Plate,
                    CameIn = item.CameIn,
                    Exited = item.Exited
                });
            }

            return Option<Exception, IQueryable<VehicleAmountViewModel>>.Of(list.AsQueryable<VehicleAmountViewModel>());
        }
    }
}
