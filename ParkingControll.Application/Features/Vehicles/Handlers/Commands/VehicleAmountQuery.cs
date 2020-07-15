using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ParkingControll.Application.Features.Vehicles.ViewModels;
using ParkingControll.Infra.CrossCutting.Structs;
using System;
using System.Linq;

namespace ParkingControll.Application.Features.Vehicles.Handlers.Commands
{
    public class VehicleAmountQuery : IRequest<Option<Exception, IQueryable<VehicleAmountViewModel>>>
    {
        public VehicleAmountQuery( )
        {
        }
        public ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        private class Validator : AbstractValidator<VehicleAmountQuery>
        {
            public Validator()
            {
            }
        }
    }
}
