using AcoTerra.Core.Common.Abstractions.Messaging;

namespace AcoTerra.Core.Features.Freights.CreateFreight;

public sealed record CreateFreightCommand(
    int TruckId,
    DateOnly LoadingDate,
    DateOnly UnloadingDate,
    string? Remarks
) : ICommand;