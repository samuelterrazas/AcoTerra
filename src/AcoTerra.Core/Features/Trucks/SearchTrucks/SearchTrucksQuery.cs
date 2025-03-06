using AcoTerra.Core.Common.Abstractions.Messaging;

namespace AcoTerra.Core.Features.Trucks.SearchTrucks;

internal sealed record SearchTrucksQuery : IQuery<List<TruckResponse>>;