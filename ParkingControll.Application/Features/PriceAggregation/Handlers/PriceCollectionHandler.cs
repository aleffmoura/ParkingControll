using MediatR;
using ParkingControll.Application.Features.PriceAggregation.Handlers.Commands;
using ParkingControll.Domain.Features.PriceAggregation;
using ParkingControll.Infra.CrossCutting.Structs;
using System;
using System.Linq;

namespace ParkingControll.Application.Features.PriceAggregation.Handlers
{

    public class PriceCollectionHandler : RequestHandler<PriceQueryAll, Option<Exception, IQueryable<Price>>>
    {
        private IPriceRepository _repository;
        public PriceCollectionHandler(IPriceRepository repository)
        {
            _repository = repository;
        }

        protected override Option<Exception, IQueryable<Price>> Handle(PriceQueryAll request)
        {
            return _repository.GetAll();
        }
    }
}
