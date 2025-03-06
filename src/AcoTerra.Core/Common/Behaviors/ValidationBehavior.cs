using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Common.Models;
using FluentValidation;
using MediatR;
using ValidationException = AcoTerra.Core.Common.Exceptions.ValidationException;

namespace AcoTerra.Core.Common.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators
) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommandMarker
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        if (!validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        List<ValidationFailure> validationErrors = validators
            .Select(validator => validator.Validate(context))
            .Where(result => result.Errors.Count > 0)
            .SelectMany(result => result.Errors)
            .Select(failure => new ValidationFailure(
                PropertyName: failure.PropertyName,
                ErrorMessage: failure.ErrorMessage
            ))
            .ToList();

        if (validationErrors.Count > 0)
        {
            throw new ValidationException(validationErrors);
        }

        return await next();
    }
}