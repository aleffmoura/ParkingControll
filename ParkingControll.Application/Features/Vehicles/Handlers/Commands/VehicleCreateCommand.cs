using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ParkingControll.Infra.CrossCutting.Structs;
using System;

namespace ParkingControll.Application.Features.Vehicles.Handlers.Commands
{
    public class VehicleCreateCommand : IRequest<Option<Exception, Guid>>
    {
        public string Plate { get; set; }

        public ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        private class Validator : AbstractValidator<VehicleCreateCommand>
        {
            public Validator()
            {
                RuleFor(a => a.Plate).NotEmpty().WithMessage("Placa do veículo não pode ser vazia");
            }
        }
    }
}
