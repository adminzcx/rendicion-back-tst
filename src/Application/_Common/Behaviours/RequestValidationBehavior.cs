namespace Prome.Viaticos.Server.Application.Common.Behaviours
{
    using FluentValidation;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext(request);

                var failures = _validators
                    .Select(validator => validator.Validate(context))
                    .SelectMany(result => result.Errors)
                    .Where(failure => failure != null)
                    .ToList();

                if (failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }
            }

            return next();
        }
    }
}
