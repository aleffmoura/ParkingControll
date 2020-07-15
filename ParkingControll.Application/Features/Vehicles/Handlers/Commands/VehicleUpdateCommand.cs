using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ParkingControll.Infra.CrossCutting.Structs;
using System;
using Unit = ParkingControll.Infra.CrossCutting.Structs.Unit;

namespace ParkingControll.Application.Features.Vehicles.Handlers.Commands
{
    public class VehicleUpdateCommand : IRequest<Option<Exception, Unit>>
    {
        public string Plate { get; set; }

        public ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        private class Validator : AbstractValidator<VehicleUpdateCommand>
        {
            public Validator()
            {
                RuleFor(a => a.Plate).NotEmpty().WithMessage("Placa está invalida");
            }
        }
    }
}
