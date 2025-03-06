using AcoTerra.Core.Common.Abstractions.Messaging;

namespace AcoTerra.Core.Features.Drivers.SearchDrivers;

public sealed record SearchDriversQuery : IQuery<List<DriverResponse>>;