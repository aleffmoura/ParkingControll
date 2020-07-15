using MediatR;
using ParkingControll.Domain.Features.PriceAggregation;
using ParkingControll.Infra.CrossCutting.Structs;
using System;
using System.Linq;

namespace ParkingControll.Application.Features.PriceAggregation.Handlers.Commands
{
    public class PriceQueryAll : IRequest<Option<Exception, IQueryable<Price>>>
    {
        public DateTime Period { get; set; }

        public PriceQueryAll(DateTime period)
        {
            Period = period;
        }
    }
}
