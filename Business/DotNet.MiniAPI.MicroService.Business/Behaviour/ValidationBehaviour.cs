
using FluentValidation;
using MediatR;
using System.Text;

namespace DotNet.MiniAPI.MicroService.Business.Behaviour
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class, IRequest<TResponse>, new()
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!_validators.Any())
            {
                return await next();
            }
            var context = new ValidationContext<TRequest>(request);
            var validationFailures = _validators
                                        .Select(validator => validator.Validate(request))
                                        .SelectMany(validationResult => validationResult.Errors)
                                        .Where(validationFailure => validationFailure != null)
                                        .ToList();

            if (validationFailures.Any())
            {
                StringBuilder error = new StringBuilder();
                foreach (var validationFailure in validationFailures)
                    error.Append(string.Format("{0}\n",validationFailure.ErrorMessage));

                throw new Exception(error.ToString());
            }
            return await next();
        }
    }
}
