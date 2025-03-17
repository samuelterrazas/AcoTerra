using AcoTerra.Core.Common.Abstractions.Messaging;
using MediatR;

namespace AcoTerra.Core.Features.Trailers.CreateTrailer;

public sealed record CreateTrailerCommand(
    string LicensePlate,
    decimal Capacity
) : ICommand<Unit>;

// TODO: Falta implementar CreateTrailerCommandHandler