using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ParkingControll.Infra.CrossCutting.Structs;
using System;

namespace ParkingControll.Application.Features.PriceAggregation.Handlers.Commands
{

    public class PriceCreateCommand : IRequest<Option<Exception, Guid>>
    {
        public int Tolerance { get; set; }
        public decimal Value { get; set; }
        public decimal Additional { get; set; }
        public DateTime Initial { get; set; }
        public DateTime Final { get; set; }

        public PriceCreateCommand()
        {

        }
        public ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        public class Validator : AbstractValidator<PriceCreateCommand>
        {
            public Validator()
            {
                RuleFor(a => a.Initial).NotEqual(default(DateTime)).WithMessage("Data inicial informada está incorreta");
                RuleFor(a => a.Final).NotEqual(default(DateTime)).WithMessage("Data final informada está incorreta");

                RuleFor(a => a.Initial).LessThan(a => a.Final).WithMessage("Data inicial deve ser menor que data final");
                RuleFor(a => a.Final).GreaterThan(a => a.Initial).WithMessage("Data final deve ser maior que data inicial");
                RuleFor(a => a.Tolerance).GreaterThan(0).WithMessage($"Tolerancia deve ser maior que: 0");
                RuleFor(a => a.Value).GreaterThan(0).WithMessage($"Valor deve ser maior que: 0");
                RuleFor(a => a.Additional).GreaterThan(0).WithMessage($"Adicional deve ser maior que: 0");


            }

        }
    }


}
