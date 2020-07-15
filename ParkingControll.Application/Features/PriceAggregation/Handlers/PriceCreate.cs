using AutoMapper;
using MediatR;
using ParkingControll.Application.Features.PriceAggregation.Handlers.Commands;
using ParkingControll.Domain.Exceptions;
using ParkingControll.Domain.Features.PriceAggregation;
using ParkingControll.Infra.CrossCutting.Structs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingControll.Application.Features.PriceAggregation.Handlers
{
    public class PriceCreate : IRequestHandler<PriceCreateCommand, Option<Exception, Guid>>
    {
        private readonly IPriceRepository _repository;

        public PriceCreate(IPriceRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<Exception, Guid>> Handle(PriceCreateCommand request, CancellationToken cancellationToken)
        {
            var allReadIn = await _repository.GetByDateAsync(request.Initial);

            if (allReadIn.IsSuccess)
                return new DuplicateException("Já existe preço com periodo inicial informado");

            var createCallBack = await _repository.CreateAsync(Mapper.Map<PriceCreateCommand, Price>(request));

            if (createCallBack.IsFailure)
                return createCallBack.Failure;

            return createCallBack.Success.Id;
        }

    }
}
