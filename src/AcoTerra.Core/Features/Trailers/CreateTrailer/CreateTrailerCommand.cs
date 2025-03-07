using AcoTerra.Core.Common.Abstractions.Messaging;

namespace AcoTerra.Core.Features.Trailers.CreateTrailer;

public sealed record CreateTrailerCommand(
    string LicensePlate,
    decimal Capacity
) : ICommand;

// TODO: Falta implementar CreateTrailerCommandHandler