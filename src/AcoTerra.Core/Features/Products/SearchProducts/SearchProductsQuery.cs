using AcoTerra.Core.Common.Abstractions.Messaging;

namespace AcoTerra.Core.Features.Products.SearchProducts;

public sealed record SearchProductsQuery : IQuery<List<ProductResponse>>;