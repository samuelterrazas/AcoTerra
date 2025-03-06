using AcoTerra.Core.Common.Models;

namespace AcoTerra.Core.Common.Exceptions;

public sealed class ValidationException(IEnumerable<ValidationFailure> errors) : Exception
{
    public IEnumerable<ValidationFailure> Errors { get; } = errors;
}