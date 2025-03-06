using AcoTerra.Core.Common.Abstractions.Messaging;

namespace AcoTerra.Core.Features.Freights.GetFreightDetails;

public sealed record GetFreightDetailsQuery(int Id) : IQuery<FreightDetailsResponse>;