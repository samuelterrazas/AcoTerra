using AcoTerra.Core.Common.Abstractions.Messaging;

namespace AcoTerra.Core.Features.Producers.SearchProducers;

public sealed record SearchProducersQuery : IQuery<List<ProducerResponse>>;