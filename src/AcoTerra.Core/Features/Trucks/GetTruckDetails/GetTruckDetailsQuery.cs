using AcoTerra.Core.Common.Abstractions.Messaging;

namespace AcoTerra.Core.Features.Trucks.GetTruckDetails;

public sealed record GetTruckDetailsQuery(int Id) : IQuery<TruckDetailsResponse>;