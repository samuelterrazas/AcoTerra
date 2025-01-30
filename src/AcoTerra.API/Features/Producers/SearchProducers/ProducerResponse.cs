namespace AcoTerra.API.Features.Producers.SearchProducers;

internal sealed record ProducerResponse(
    int Id,
    string Name,
    string IdentificationType,
    string IdentificationNumber,
    string PhoneNumber,
    string? Email
);