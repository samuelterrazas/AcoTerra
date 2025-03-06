namespace AcoTerra.Core.Common.Models;

public sealed record ValidationFailure(
    string PropertyName,
    string ErrorMessage
);