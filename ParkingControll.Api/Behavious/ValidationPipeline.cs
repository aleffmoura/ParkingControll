using FluentValidation;
using MediatR;
using ParkingControll.Infra.CrossCutting.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingControll.Api.Behavious
{
    public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, Option<Exception, TResponse>>
        where TRequest : IRequest<Option<Exception, TResponse>>
    {
        private readonly IValidator<TRequest>[] _validators;

        public ValidationPipeline(IValidator<TRequest>[] validators)
        {
            _validators = validators;
        }

        public async Task<Option<Exception, TResponse>> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Option<Exception, TResponse>> next)
        {
            List<FluentValidation.Results.ValidationFailure> failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
                return new ValidationException(failures);

            return await next();
        }
    }
}
